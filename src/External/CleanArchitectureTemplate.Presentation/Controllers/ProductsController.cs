using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;
using CleanArchitectureTemplate.Application.Services;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Infrastructure.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ProductsController(IMediator _mediator) : ControllerBase
{
    [RoleFilter("Create")]
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAsync(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var query = await _mediator.Send(request, cancellationToken);
        return Ok(query);
    }

    [NonAction]
    public void Delete(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [RoleFilter("GetAll")]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllAsync(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        PagedResult<Product> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [NonAction]
    public Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [NonAction]
    public void Update(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
