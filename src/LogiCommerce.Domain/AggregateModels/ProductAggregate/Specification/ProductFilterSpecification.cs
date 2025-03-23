namespace LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;

using Ardalis.Specification;

public class ProductFilterSpecification : Specification<Product>
{
    public ProductFilterSpecification(string keyword, int? minStock, int? maxStock)
    {
        Query.Include(p => p.Category);
        
        if (!string.IsNullOrEmpty(keyword))
        {
            Query.Where(p =>
                p.Title.ToLower().Contains(keyword.ToLower()) ||
                p.Description.ToLower().Contains(keyword.ToLower()) ||
                p.Category.Name.ToLower().Contains(keyword.ToLower()));
        }
        
        if (minStock.HasValue)
        {
            Query.Where(p => p.StockQuantity >= minStock.Value);
        }
        
        if (maxStock.HasValue)
        {
            Query.Where(p => p.StockQuantity <= maxStock.Value);
        }
        
        Query.Where(p=> p.DeletedOn == null);
    }
}
