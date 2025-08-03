using AutoMapper;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureTemplate.Application.IServices;
using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Persistance.Services;

public class AuthService(UserManager<User> _userManager, IMapper _mapper, IJwtGenerator _jwtGenator) : IAuthService
{
    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.Users.Where(u => u.UserName == request.UserNameOrEmail || u.Email == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);

        if (user == null)
            throw new Exception("User not found");

        bool IsValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!IsValidPassword)
            throw new Exception("Invalid password");

        LoginCommandResponse response = await _jwtGenator.CreateTokenAsync(user);
        return response;
    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = _mapper.Map<User>(request);
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);
    }
}
