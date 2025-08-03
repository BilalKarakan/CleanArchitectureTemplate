using CleanArchitectureTemplate.Application.CommonResponses;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;

public record RegisterCommand(string Name, string LastName, string UserName, string Email, string Password, string PhoneNumber) : IRequest<CommonResponse>;
