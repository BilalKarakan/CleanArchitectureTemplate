using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Infrastructure.Authorization;

public class RoleFilterAttribute : TypeFilterAttribute
{
    public RoleFilterAttribute(string role) : base(typeof(RoleAttibute))
    {
        this.Arguments = new object[] { role };
    }
}
