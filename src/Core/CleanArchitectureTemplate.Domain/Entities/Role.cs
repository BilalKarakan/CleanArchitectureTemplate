using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureTemplate.Domain.Entities;

public class Role : IdentityRole<string>
{
    public Role()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}
