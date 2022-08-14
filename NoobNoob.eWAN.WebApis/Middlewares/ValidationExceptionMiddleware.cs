using FluentValidation;
using NoobNoob.eWAN.Application.Contracts.Responses;

namespace NoobNoob.eWAN.WebApis.Middlewares;

public class ValidationExceptionMiddleware
{
    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    private readonly RequestDelegate _next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;
            var messages = ex.Errors.Select(x => x.ErrorMessage).ToList();
            var validationFailureResponse = new ValidationFailureResponse
            {
                Errors = messages
            };
            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
}