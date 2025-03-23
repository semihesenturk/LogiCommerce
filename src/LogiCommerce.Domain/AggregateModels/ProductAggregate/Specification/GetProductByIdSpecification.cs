using Ardalis.Specification;

namespace LogiCommerce.Domain.AggregateModels.ProductAggregate.Specification;

public class GetProductByIdSpecification : Specification<Product>
{
    public GetProductByIdSpecification(Guid productId)
    {
        Query.Where(p => p.Id == productId && p.DeletedOn == null);
    }
}