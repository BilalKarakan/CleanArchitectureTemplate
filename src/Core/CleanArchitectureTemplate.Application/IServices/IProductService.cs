using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.Services;

public interface IProductService
{
    Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken = default);
    Task GetAllAsync();
    Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    void Update(Product product, CancellationToken cancellationToken = default);
    void Delete(Product product, CancellationToken cancellationToken = default);
}
