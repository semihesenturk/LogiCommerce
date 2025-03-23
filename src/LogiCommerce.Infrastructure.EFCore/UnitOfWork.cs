using LogiCommerce.Domain.Generics;

namespace LogiCommerce.Infrastructure.EFCore;

public class UnitOfWork(LogiCommerceDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync();
    }
}