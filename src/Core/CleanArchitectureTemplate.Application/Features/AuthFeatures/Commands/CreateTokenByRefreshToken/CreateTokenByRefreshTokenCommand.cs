using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshToken;

public record CreateTokenByRefreshTokenCommand(string UserId, string RefreshToken) : IRequest<LoginCommandResponse>;
