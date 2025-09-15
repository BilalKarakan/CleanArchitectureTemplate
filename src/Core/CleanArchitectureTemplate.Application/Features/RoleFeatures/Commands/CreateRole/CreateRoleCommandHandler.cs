using CleanArchitectureTemplate.Application.CommonResponses;
using CleanArchitectureTemplate.Application.IServices;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.RoleFeatures.Commands.CreateRole;

public class CreateRoleCommandHandler(IRoleService _roleService) : IRequestHandler<CreateRoleCommand, CommonResponse>
{
    public async Task<CommonResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.CreateAsync(request);
        return new CommonResponse("Role was created successfully!"); 
    }
}
