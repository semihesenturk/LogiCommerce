using Ardalis.Specification;

namespace LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;

public class GetProductByKeywordSpecification : Specification<Product>
{
    public GetProductByKeywordSpecification(string keyword)
    {
        Query.Where(p => p.Title.Contains(keyword) ||
                         p.Description.Contains(keyword) ||
                         p.Category.Name.Contains(keyword));
    }
}