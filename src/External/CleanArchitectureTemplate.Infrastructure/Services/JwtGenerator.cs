using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureTemplate.Application.IServices;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitectureTemplate.Infrastructure.Services;

public class JwtGenerator : IJwtGenerator
{
    private readonly JwtOptions _jwtoptions;
    private readonly UserManager<User> _userManager;
    public JwtGenerator(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager)
    {
        _jwtoptions = jwtOptions.Value;
        _userManager = userManager;
    }
    public async Task<LoginCommandResponse> CreateTokenAsync(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            
        };

        DateTime expires = DateTime.Now.AddMinutes(30);  

        JwtSecurityToken jwtSecurityToken = new
            (
                issuer: _jwtoptions.Issuer,
                audience: _jwtoptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtoptions.SecretKey)), algorithm: SecurityAlgorithms.HmacSha256)
            );
        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpire = expires.AddMinutes(10);
        _userManager.UpdateAsync(user);

        LoginCommandResponse response = new
            (
                Token: token,
                RefreshToken: refreshToken,
                RefreshTokenExpire: user.RefreshTokenExpire,
                UserId: user.Id
            );

        return response;
    }
}
