using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using LogiCommerce.Domain.Generics;
using Microsoft.EntityFrameworkCore;

namespace LogiCommerce.Infrastructure.EFCore.Repositories;

public class RepositoryBase<T>(LogiCommerceDbContext context, IUnitOfWork unitOfWork) : IRepository<T>
    where T : class
{
    private readonly LogiCommerceDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IUnitOfWork UnitOfWork { get; } = unitOfWork; 

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator.Default.GetQuery(_dbSet.AsQueryable(), spec);
    }
}
