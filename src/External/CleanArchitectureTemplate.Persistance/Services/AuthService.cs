using AutoMapper;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureTemplate.Application.IServices;
using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureTemplate.Persistance.Services;

public class AuthService(UserManager<User> _userManager, IMapper _mapper) : IAuthService
{
    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = _mapper.Map<User>(request);
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);
    }
}
