using LogiCommerce.Domain.AggregateModels.ProductAggregate;

namespace LogiCommerce.Infrastructure.EFCore.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(LogiCommerceDbContext context) : base(context)
    {
    }
}