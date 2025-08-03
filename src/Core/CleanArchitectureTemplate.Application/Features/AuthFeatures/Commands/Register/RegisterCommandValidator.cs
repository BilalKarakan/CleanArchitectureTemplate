using FluentValidation;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName).NotNull().WithMessage("Username Must Not Be Null!").NotEmpty().WithMessage("Username Must Not Be Empty!")
            .MaximumLength(100).WithMessage("Username Must Not Exceed 100 Characters!").MinimumLength(3).WithMessage("Username must be at least 3 characters!");

        RuleFor(x => x.Email).NotNull().WithMessage("Email must not be null!").NotEmpty().WithMessage("Email is required")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters!").MinimumLength(5).WithMessage("Email must be at least 5 characters!");

        RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Phone Number must not be null!").NotEmpty().WithMessage("Phone Number is required")
            .MaximumLength(15).WithMessage("Phone Number must not exceed 15 characters!").MinimumLength(10).WithMessage("Phone Number must be at least 10 characters!");

        RuleFor(x => x.Password).NotNull().WithMessage("Password must not be null!").NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters!")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters!")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character!");

        RuleFor(x => x.Name).NotNull().WithMessage("Name Must Not Be Empty!").NotEmpty().WithMessage("Name Must Not Be Empty!").MaximumLength(100).WithMessage("Name Must Not Exceed 100 Characters!").MinimumLength(2).WithMessage("Name must be at least 2 characters!");
        RuleFor(x => x.LastName).NotNull().WithMessage("LastName Must Not Be Empty!").NotEmpty().WithMessage("LastName Must Not Be Empty!").MaximumLength(100).WithMessage("lastName Must Not Exceed 100 Characters!").MinimumLength(1).WithMessage("LastName must be at least 2 characters!");
    }
}
