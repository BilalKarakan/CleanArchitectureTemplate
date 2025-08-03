using CleanArchitectureTemplate.Application.IServices;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;

public class LoginCommandHandler(IAuthService _authService) : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.LoginAsync(request, cancellationToken);
    }
}
