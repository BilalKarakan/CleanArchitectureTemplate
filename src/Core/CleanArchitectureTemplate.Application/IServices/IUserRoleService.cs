using CleanArchitectureTemplate.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

namespace CleanArchitectureTemplate.Application.IServices;

public interface IUserRoleService
{
    Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
}
