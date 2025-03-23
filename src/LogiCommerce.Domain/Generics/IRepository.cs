using Ardalis.Specification;

namespace LogiCommerce.Domain.Generics;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default(CancellationToken));
    Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default(CancellationToken));
    Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    IUnitOfWork UnitOfWork { get; }
}