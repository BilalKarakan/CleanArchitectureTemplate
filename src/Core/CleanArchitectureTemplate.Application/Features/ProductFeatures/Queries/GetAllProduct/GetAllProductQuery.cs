using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Domain.Entities;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductFeatures.Queries.GetAllProduct;

public record GetAllProductQuery(int PageNumber = 1, int PageSize = 10, string Search = "") : IRequest<PagedResult<Product>>;
