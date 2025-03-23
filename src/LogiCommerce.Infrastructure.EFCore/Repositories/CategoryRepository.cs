using LogiCommerce.Domain.AggregateModels.CategoryAggregate;
using LogiCommerce.Domain.Generics;

namespace LogiCommerce.Infrastructure.EFCore.Repositories;

public class CategoryRepository(LogiCommerceDbContext context, IUnitOfWork unitOfWork) : RepositoryBase<Category>(context, unitOfWork), ICategoryRepository
{
    
}