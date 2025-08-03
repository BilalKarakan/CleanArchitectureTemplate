using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureTemplate.Application.IServices;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshToken;

public class CreateTokenByRefreshTokenCommandHandler(IAuthService _authService) : IRequestHandler<CreateTokenByRefreshTokenCommand, LoginCommandResponse>
{
    public Task<LoginCommandResponse> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken) =>  _authService.CreateTokenByRefreshToken(request, cancellationToken);
}
