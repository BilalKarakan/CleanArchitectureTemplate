namespace CleanArchitectureTemplate.Domain.IRepositories;

public interface IGenericCommandRepository<T> where T : class
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}
