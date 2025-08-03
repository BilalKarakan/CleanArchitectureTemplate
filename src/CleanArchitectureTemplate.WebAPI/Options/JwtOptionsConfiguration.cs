using CleanArchitectureTemplate.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace CleanArchitectureTemplate.WebAPI.Options;

public class JwtOptionsConfiguration : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;
    public JwtOptionsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(JwtOptions options)
    {
        _configuration.GetSection("Jwt").Bind(options);
    }
}
