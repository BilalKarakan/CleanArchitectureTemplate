using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;

namespace CleanArchitectureTemplate.Application.IServices;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
}
