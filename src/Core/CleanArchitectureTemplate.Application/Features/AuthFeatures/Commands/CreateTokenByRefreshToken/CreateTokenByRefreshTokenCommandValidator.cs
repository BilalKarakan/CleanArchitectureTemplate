using FluentValidation;

namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshToken;

public class CreateTokenByRefreshTokenCommandValidator : AbstractValidator<CreateTokenByRefreshTokenCommand>
{
    public CreateTokenByRefreshTokenCommandValidator()
    {
        RuleFor(u => u.UserId).NotNull().WithMessage("UserId must not be null!").NotEmpty().WithMessage("UserId must not be empty!");
        RuleFor(u => u.RefreshToken).NotNull().WithMessage("Refresh Token must not be null!").NotEmpty().WithMessage("Refresh Token must not be empty!");
    }
}
