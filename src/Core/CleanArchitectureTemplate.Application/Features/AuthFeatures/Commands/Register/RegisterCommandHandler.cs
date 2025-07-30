using CleanArchitectureTemplate.Application.CommonResponses;
using CleanArchitectureTemplate.Application.IServices;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;

public class RegisterCommandHandler(IAuthService _service) : IRequestHandler<RegisterCommand, CommonResponse>
{
    public async Task<CommonResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _service.RegisterAsync(request);
        return new("User created!");
    }
}
