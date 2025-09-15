using CleanArchitectureTemplate.Domain.Entitie;

namespace CleanArchitectureTemplate.Domain.IRepositories;

public interface IUserRoleRepository : IGenericCommandRepository<UserRole>, IGenericQueryRepository<UserRole>
{
}
