using CleanArchitectureTemplate.Application.CommonResponses;
using CleanArchitectureTemplate.Application.Services;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;

public class CreateProductHandler(IProductService _service) : IRequestHandler<CreateProductCommand, CommonResponse>
{
    public async Task<CommonResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(request, cancellationToken);
        return new CommonResponse("The operation is success!");
    }
}
