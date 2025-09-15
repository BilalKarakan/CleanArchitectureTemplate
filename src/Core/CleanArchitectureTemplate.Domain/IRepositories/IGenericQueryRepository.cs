using System.Linq.Expressions;

namespace CleanArchitectureTemplate.Domain.IRepositories;

public interface IGenericQueryRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    IQueryable<T> GetQueryable(CancellationToken cancellationToken);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
}
