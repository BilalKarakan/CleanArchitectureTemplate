using CleanArchitectureTemplate.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CleanArchitectureTemplate.Infrastructure.Authorization;

public class RoleAttibute(string _role, IUserRoleRepository _repository) : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userHasRole = _repository.GetWhere(u => u.UserId == userIdClaim.Value).Include(r => r.Role).Any(r => r.Role.Name == _role);

        if (!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
