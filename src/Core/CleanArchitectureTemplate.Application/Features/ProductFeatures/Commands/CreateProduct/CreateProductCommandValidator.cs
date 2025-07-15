using FluentValidation;

namespace CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name must not be null.")
            .MaximumLength(200).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.")
            .NotNull().WithMessage("Price must not be null.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is required.")
            .NotNull().WithMessage("Quantity must not be null.")
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to zero.");
    }
}
