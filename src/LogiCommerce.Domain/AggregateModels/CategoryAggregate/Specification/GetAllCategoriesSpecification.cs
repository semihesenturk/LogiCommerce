using Ardalis.Specification;

namespace LogiCommerce.Domain.AggregateModels.CategoryAggregate.Specification;

public class GetAllCategoriesSpecification : Specification<Category>
{
    public GetAllCategoriesSpecification()
    {
        Query.Include(x => x.Products);
        Query.Where(x => x.DeletedOn == null);
    }
}