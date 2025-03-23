using Ardalis.Specification;

namespace LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;

public class GetCategoryByIdSpecification : Specification<Category>
{
    public GetCategoryByIdSpecification(Guid categoryId)
    {
        Query.Where(category => category.Id == categoryId && category.DeletedOn != null);
    }
}