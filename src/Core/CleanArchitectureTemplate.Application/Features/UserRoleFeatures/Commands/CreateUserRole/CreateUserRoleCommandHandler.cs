using CleanArchitectureTemplate.Application.CommonResponses;
using CleanArchitectureTemplate.Application.IServices;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleCommandHandler(IUserRoleService _service) : IRequestHandler<CreateUserRoleCommand, CommonResponse>
{
    public async Task<CommonResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(request, cancellationToken);
        return new CommonResponse("User and role relationships have been established.");
    }
}
