using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
using CleanArchitectureTemplate.Application.Services;
using CleanArchitectureTemplate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Presentation.Controllers;

public class ProductsController(IMediator _mediator) : ControllerBase, IProductService
{
    [HttpPost("[action]")]
    public async Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken = default) => Ok(await _mediator.Send(request, cancellationToken));

    [NonAction]
    public void Delete(Product product, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [NonAction]
    public Task GetAllAsync()
    {
        throw new NotImplementedException();
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
