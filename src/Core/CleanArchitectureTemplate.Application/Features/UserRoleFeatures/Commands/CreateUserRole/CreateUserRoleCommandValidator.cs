using FluentValidation;

namespace CleanArchitectureTemplate.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(x => x.UserId).NotNull().WithMessage("UserId is required").NotEmpty().WithMessage("UserId is require");
        RuleFor(x => x.RoleId).NotNull().WithMessage("RoleId is required").NotEmpty().WithMessage("RoleId is require");
    }
}
