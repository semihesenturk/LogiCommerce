using Ardalis.Specification;

namespace LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;

public class GetProductByKeywordSpecification : Specification<Product>
{
    public GetProductByKeywordSpecification(string keyword)
    {
        var lowerKeyword = keyword.ToLower();
        
        Query.Include(p=>p.Category);
        Query.Where(p => p.Title.ToLower().Contains(lowerKeyword) ||
                         p.Description.ToLower().Contains(lowerKeyword) ||
                         p.Category.Name.ToLower().Contains(lowerKeyword));
    }
}