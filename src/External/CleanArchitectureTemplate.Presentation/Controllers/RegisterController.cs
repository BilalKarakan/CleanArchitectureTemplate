using CleanArchitectureTemplate.Application.CommonResponses;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Presentation.Controllers;

public class RegisterController(IMediator _mediator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand request, CancellationToken cancellationToken)
    {
        CommonResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
