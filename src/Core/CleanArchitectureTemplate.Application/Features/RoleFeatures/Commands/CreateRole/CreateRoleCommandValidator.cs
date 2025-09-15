using FluentValidation;

namespace CleanArchitectureTemplate.Application.Features.RoleFeatures.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("Name is required").NotEmpty().WithMessage("Name is required");
    }
}
