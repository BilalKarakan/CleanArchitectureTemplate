using CleanArchitectureTemplate.Application.Services;
using CleanArchitectureTemplate.Domain.Entities;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;

public class GetAllProductQueryHandler(IProductService _service) : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = await _service.GetAllAsync(request, cancellationToken);
        return products;
    }
}
