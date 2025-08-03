using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.IServices;

public interface IJwtGenerator
{
    string CreateToken(User user);
}
