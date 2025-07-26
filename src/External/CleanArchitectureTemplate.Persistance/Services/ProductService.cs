using AutoMapper;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;
using CleanArchitectureTemplate.Application.Services;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.IRepositories;

namespace CleanArchitectureTemplate.Persistance.Services;

public class ProductService(IProductRepository _repository, IMapper _mapper) : IProductService
{
    public async Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken = default) => await _repository.CreateAsync(_mapper.Map<Product>(request));

    public void Delete(Product product, CancellationToken cancellationToken = default) => _repository.Delete(product);

    public async Task<IEnumerable<Product>> GetAllAsync(GetAllProductQuery request, CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);

    public async Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken = default) => await _repository.GetByIdAsync(id);

    public void Update(Product product, CancellationToken cancellationToken = default) => _repository.Update(product);
}
