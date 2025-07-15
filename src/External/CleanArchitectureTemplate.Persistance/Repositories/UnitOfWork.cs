using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Persistance.Repositories;

public class UnitOfWork(ApplicationDbContext _context) : IUnitOfWork
{
    public void SaveChanges() => _context.SaveChanges();

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
