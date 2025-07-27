using AutoMapper;
using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;
using CleanArchitectureTemplate.Application.Services;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Persistance.Services;

public class ProductService(IProductRepository _repository, IMapper _mapper) : IProductService
{
    public async Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken = default) => await _repository.CreateAsync(_mapper.Map<Product>(request));

    public void Delete(Product product, CancellationToken cancellationToken = default) => _repository.Delete(product);

    public async Task<PagedResult<Product>> GetAllAsync(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Product> products = _repository.GetQueryable(cancellationToken);
        if (!string.IsNullOrEmpty(request.Search))
        {
            products = products.Where(p => p.Name.Contains(request.Search, StringComparison.OrdinalIgnoreCase));
        }

        int totalCount = await products.CountAsync(cancellationToken);

        var items = await products.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);
        return new PagedResult<Product>(items, totalCount, request.PageNumber, request.PageSize);
    }
    public async Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken = default) => await _repository.GetByIdAsync(id);

    public void Update(Product product, CancellationToken cancellationToken = default) => _repository.Update(product);
}
