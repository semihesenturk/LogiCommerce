namespace LogiCommerce.Infrastructure.EFCore;

public class UnitOfWork(LogiCommerceDbContext context)
{
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}