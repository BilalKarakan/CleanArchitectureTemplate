namespace CleanArchitectureTemplate.Domain.IRepositories;

public interface IGenericQueryRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
}
