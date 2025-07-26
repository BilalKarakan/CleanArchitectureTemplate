using CleanArchitectureTemplate.Domain.Entities;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
}
