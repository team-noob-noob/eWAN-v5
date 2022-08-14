using FastEndpoints;
using FastEndpoints.Swagger;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.Application.Interfaces.Repositories;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Services;
using NoobNoob.eWAN.Infrastructure.Data.InMemory.Repositories;
using NoobNoob.eWAN.WebApis.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddSingleton<ISubjectRepository, SubjectRepository>();
builder.Services.AddSingleton<ISubjectService, SubjectService>();

var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse()
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList(),
        };
    };
});
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());


app.Run();