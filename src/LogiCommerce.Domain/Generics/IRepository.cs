using Ardalis.Specification;

namespace LogiCommerce.Domain.Generics;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    IUnitOfWork UnitOfWork { get; }
}