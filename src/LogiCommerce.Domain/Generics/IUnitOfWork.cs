namespace LogiCommerce.Domain.Generics;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}