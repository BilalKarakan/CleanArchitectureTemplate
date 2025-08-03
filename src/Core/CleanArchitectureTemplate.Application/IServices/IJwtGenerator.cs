using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.IServices;

public interface IJwtGenerator
{
    Task<LoginCommandResponse> CreateTokenAsync(User user);
}