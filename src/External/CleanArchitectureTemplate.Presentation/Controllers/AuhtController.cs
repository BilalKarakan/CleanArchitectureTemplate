using CleanArchitectureTemplate.Application.CommonResponses;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Presentation.Controllers;

public class AuhtController(IMediator _mediator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand request, CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));

    [HttpPost("[action]")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginCommand request, CancellationToken cancellationToken) => Ok(await _mediator.Send(request, cancellationToken));
}
