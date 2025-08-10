using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureTemplate.Application.IServices;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshToken;

public class CreateTokenByRefreshTokenCommandHandler(IAuthService _authService) : IRequestHandler<CreateTokenByRefreshTokenCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken) =>  await _authService.CreateTokenByRefreshToken(request, cancellationToken);
}
