using LogiCommerce.Domain.Generics;

namespace LogiCommerce.Infrastructure.EFCore;

public class UnitOfWork(LogiCommerceDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}