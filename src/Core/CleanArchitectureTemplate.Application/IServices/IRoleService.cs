using CleanArchitectureTemplate.Application.Features.RoleFeatures.Commands.CreateRole;

namespace CleanArchitectureTemplate.Application.IServices;

public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand request);
}
