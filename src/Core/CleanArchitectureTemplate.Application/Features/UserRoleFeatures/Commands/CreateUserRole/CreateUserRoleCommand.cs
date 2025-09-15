using CleanArchitectureTemplate.Application.CommonResponses;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public record CreateUserRoleCommand(string UserId, string RoleId) : IRequest<CommonResponse>;
