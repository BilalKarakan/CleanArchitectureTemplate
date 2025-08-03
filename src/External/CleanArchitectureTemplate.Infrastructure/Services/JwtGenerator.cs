using CleanArchitectureTemplate.Application.IServices;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Infrastructure.Authentication;
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
    public JwtGenerator(IOptions<JwtOptions> jwtOptions)
    {
        _jwtoptions = jwtOptions.Value;
    }
    public string CreateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, user.Id)
        };

        JwtSecurityToken jwtSecurityToken = new
            (
                issuer: _jwtoptions.Issuer,
                audience: _jwtoptions.Audience,
                claims: null,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtoptions.SecretKey)), algorithm: SecurityAlgorithms.HmacSha256)
            );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
