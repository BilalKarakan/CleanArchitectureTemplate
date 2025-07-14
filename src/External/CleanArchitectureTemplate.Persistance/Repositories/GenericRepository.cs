using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Persistance.Repositories;

public class GenericRepository<T>(ApplicationDbContext _context) : IGenericCommandRepository<T>, IGenericQueryRepository<T> where T : class
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default) => await _context.Set<T>().AddAsync(entity);

    public void Delete(T entity, CancellationToken cancellationToken = default) => _context.Set<T>().Remove(entity);

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default) => await _context.Set<T>().FindAsync(id);

    public void Update(T entity, CancellationToken cancellationToken = default) => _context.Set<T>().Update(entity);
}
