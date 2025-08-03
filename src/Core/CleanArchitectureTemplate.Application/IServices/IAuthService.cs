using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;

namespace CleanArchitectureTemplate.Application.IServices;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
}
