using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Application.Services;
using CleanArchitectureTemplate.Domain.Entities;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;

public class GetAllProductQueryHandler(IProductService _service) : IRequestHandler<GetAllProductQuery, PagedResult<Product>>
{
    public async Task<PagedResult<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllAsync(request, cancellationToken);
    }
}
