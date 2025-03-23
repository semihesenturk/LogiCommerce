namespace LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;

using Ardalis.Specification;

public class ProductFilterSpecification : Specification<Product>
{
    public ProductFilterSpecification(string keyword, int? minStock, int? maxStock)
    {
        // Category'i include ederek ilişkili verileri getiriyoruz
        Query.Include(p => p.Category);

        // Eğer keyword parametresi varsa, filtreleme yapıyoruz
        if (!string.IsNullOrEmpty(keyword))
        {
            // Keyword ile ilgili Title, Description ve Category.Name üzerinde büyük/küçük harf duyarsız arama yapıyoruz
            Query.Where(p =>
                p.Title.ToLower().Contains(keyword.ToLower()) ||
                p.Description.ToLower().Contains(keyword.ToLower()) ||
                p.Category.Name.ToLower().Contains(keyword.ToLower()));
        }

        // Eğer minStock parametresi varsa, stok miktarını filtreliyoruz
        if (minStock.HasValue)
        {
            Query.Where(p => p.StockQuantity >= minStock.Value);
        }

        // Eğer maxStock parametresi varsa, stok miktarını filtreliyoruz
        if (maxStock.HasValue)
        {
            Query.Where(p => p.StockQuantity <= maxStock.Value);
        }
        
        Query.Where(p=> p.DeletedOn == null);
    }
}
