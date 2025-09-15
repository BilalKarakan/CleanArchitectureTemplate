using CleanArchitectureTemplate.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class UserRolesController(IMediator _mediator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));
}
