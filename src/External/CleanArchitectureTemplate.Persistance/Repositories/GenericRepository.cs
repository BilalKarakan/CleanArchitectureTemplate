using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;
using MediatR.NotificationPublishers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Persistance.Repositories;

public class GenericRepository<T>(ApplicationDbContext _context, IUnitOfWork _unitOfWork) : IGenericCommandRepository<T>, IGenericQueryRepository<T> where T : class
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default) => await _context.Set<T>().FindAsync(id);

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _unitOfWork.SaveChanges();
    }

    public IQueryable<T> GetQueryable(CancellationToken cancellationToken) => _context.Set<T>().AsQueryable();

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
    {
        var result = _context.Set<T>().Where(expression);
        return result;
    }
}
