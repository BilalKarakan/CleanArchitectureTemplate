using CleanArchitectureTemplate.Application.CommonResponses;
using CleanArchitectureTemplate.Domain.Entities;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;

public record CreateProductCommand(string Name, string Description, int Quantity, decimal Price, string CategoryId) : IRequest<CommonResponse>;
