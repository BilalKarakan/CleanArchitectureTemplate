using FluentValidation;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(u => u.UserNameOrEmail).NotNull().WithMessage("UserName Or Email Must Not Be Empty!").NotEmpty().WithMessage("UserName Or Email Must Not Be Empty!");
        RuleFor(u => u.Password).NotNull().WithMessage("Password Must Not Be Empty").NotEmpty().WithMessage("Password Must not Be Empty");
    }
}
