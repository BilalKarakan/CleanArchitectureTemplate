using MediatR;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;

public record LoginCommand(string UserNameOrEmail, string Password) : IRequest<LoginCommandResponse>;
