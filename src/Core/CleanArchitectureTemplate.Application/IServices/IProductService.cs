using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.Services;

public interface IProductService
{
    Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetAllAsync(GetAllProductQuery request, CancellationToken cancellationToken = default);
    Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    void Update(Product product, CancellationToken cancellationToken = default);
    void Delete(Product product, CancellationToken cancellationToken = default);
}
