using Ardalis.Specification;

namespace LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;

public class GetCategoryWithProductsSpecification : Specification<Category>
{
    public GetCategoryWithProductsSpecification(Guid categoryId)
    {
        Query.Where(c => c.Id == categoryId)
            .Include(c => c.Products);
    }
}