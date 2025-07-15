using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchitectureTemplate.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validator;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
    {
        _validator = validator;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validator.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var errorDictionary = _validator.Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(x => x.PropertyName, x => x.ErrorMessage, (propertyName, errorMessage) => new
            {
                Key = propertyName,
                Values = errorMessage.Distinct().ToArray()
            }).ToDictionary(x => x.Key, x => x.Values[0]);

        if (errorDictionary.Any())
        {
            var errors = errorDictionary.Select(x => new ValidationFailure
            {
                PropertyName = x.Key,
                ErrorMessage = x.Value
            });
            throw new ValidationException(errors);
        }

        return await next();
    }
}
