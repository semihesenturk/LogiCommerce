using LogiCommerce.Domain.AggregateModels.ProductAggregate;
using LogiCommerce.Domain.Generics;

namespace LogiCommerce.Infrastructure.EFCore.Repositories;

public class ProductRepository(LogiCommerceDbContext context, IUnitOfWork unitOfWork)
    : RepositoryBase<Product>(context, unitOfWork), IProductRepository;