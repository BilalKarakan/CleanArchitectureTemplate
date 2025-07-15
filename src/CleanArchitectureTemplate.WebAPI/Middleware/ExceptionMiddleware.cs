using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;
using FluentValidation;

namespace CleanArchitectureTemplate.WebAPI.Middleware;

public class ExceptionMiddleware(ApplicationDbContext _context, IUnitOfWork _unitOfWork) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await LogExceptionToDatabaseAsync(context, ex);
            await HandleExceptionAsync(context, ex);
        }
    }

	private Task HandleExceptionAsync(HttpContext context, Exception ex)
	{
		context.Response.ContentType = "application/json";

		if (ex is ValidationException validationException)
		{
			context.Response.StatusCode = 403;

			return context.Response.WriteAsync(new ValidationErrorDetails
			{
				Errors = validationException.Errors.Select(e => e.ErrorMessage),
				StatusCode = context.Response.StatusCode
            }.ToString());
		}

		context.Response.StatusCode = 500;

		return context.Response.WriteAsync(new ErrorResult
		{
			Message = ex.Message,
			StatusCode = context.Response.StatusCode
		}.ToString());
    }

	private async Task LogExceptionToDatabaseAsync(HttpContext context, Exception ex)
	{
		ErrorLog errorLog = new ErrorLog
		{
			ErrorMessage = ex.Message,
			StackTrace = ex.StackTrace ?? string.Empty,
			RequestPath = context.Request.Path,
			RequestMethod = context.Request.Method,
			TimeStamp = DateTime.Now
        };

		await _context.ErrorLogs.AddAsync(errorLog, default);
		await _unitOfWork.SaveChangesAsync(default);
    }
}
