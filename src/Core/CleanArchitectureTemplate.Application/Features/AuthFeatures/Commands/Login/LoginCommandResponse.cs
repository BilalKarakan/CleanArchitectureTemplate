namespace CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Login;

public record LoginCommandResponse(string Token, string RefreshToken, DateTime? RefreshTokenExpire, string UserId);
