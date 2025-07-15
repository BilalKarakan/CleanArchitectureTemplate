namespace CleanArchitectureTemplate.Domain.IRepositories;

public interface IUnitOfWork
{
    public void SaveChanges();
    public Task SaveChangesAsync();
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
