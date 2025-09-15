using CleanArchitectureTemplate.Application.Features.RoleFeatures.Commands.CreateRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Presentation.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class RolesController(IMediator _mediator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAsync(CreateRoleCommand request, CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));
}
