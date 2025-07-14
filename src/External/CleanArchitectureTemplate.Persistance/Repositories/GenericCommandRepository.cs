using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;

namespace CleanArchitectureTemplate.Persistance.Repositories;

public class GenericCommandRepository<T>(ApplicationDbContext _context) : IGenericCommandRepository<T> where T : class
{
    public async Task CreateAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);
}
