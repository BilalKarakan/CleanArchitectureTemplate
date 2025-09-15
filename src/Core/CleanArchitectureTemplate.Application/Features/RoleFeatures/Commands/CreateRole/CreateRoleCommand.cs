using CleanArchitectureTemplate.Application.CommonResponses;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.RoleFeatures.Commands.CreateRole;

public record CreateRoleCommand(string Name) : IRequest<CommonResponse>;
