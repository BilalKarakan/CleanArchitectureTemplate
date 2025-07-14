using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Persistance.Repositories;

public class GenericQueryRepository<T>(ApplicationDbContext _context) : IGenericQueryRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(string id) => await _context.Set<T>().FindAsync(id);
}
