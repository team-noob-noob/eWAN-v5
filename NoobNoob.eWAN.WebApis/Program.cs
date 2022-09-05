using FastEndpoints;
using FastEndpoints.Swagger;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.Application.Interfaces.Repositories;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Services;
using NoobNoob.eWAN.Infrastructure.Data.EfCoreCosmos;
using NoobNoob.eWAN.Infrastructure.Data.EfCoreCosmos.Repositories;
using NoobNoob.eWAN.Infrastructure.Data.EfCoreCosmos.Services;
using NoobNoob.eWAN.WebApis.Middlewares;
using NSwag;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();        
    });
});
builder.Services.AddSwaggerDoc(options =>
{
    options.AddAuth("OAuth2", new OpenApiSecurityScheme()
    {
        Type = OpenApiSecuritySchemeType.OAuth2,
 
        Flows = new OpenApiOAuthFlows()
        {
            AuthorizationCode = new OpenApiOAuthFlow()
            {
#if DEBUG
                AuthorizationUrl = "https://localhost:5002/connect/authorize",
                TokenUrl = "https://localhost:5002/connect/token",
#else
                AuthorizationUrl = Environment.GetEnvironmentVariable("IDENTITY_AUTHORIZATION_URL"),
                TokenUrl = Environment.GetEnvironmentVariable("IDENTITY_TOKEN_URL"),
#endif
                
                Scopes = new Dictionary<string, string>()
                {
                    {"APIS", "Access the WebApis"}
                }
            }
        }
    });
}, addJWTBearerAuth: false);
builder.Services.AddDbContext<EwanCosmosDbContext>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<ISubjectRepository, SubjectRepository>();
builder.Services.AddSingleton<ISubjectService, SubjectService>();
builder.Services.AddAuthorization();
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5002";
        options.Audience = "APIS";
#if DEBUG
        options.RequireHttpsMetadata = false;
#endif
    });

var app = builder.Build();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
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
app.UseSwaggerUi3(settings =>
{
    settings.OAuth2Client = new OAuth2ClientSettings()
    {
#if DEBUG
        ClientId = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
        ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
#else
        ClientId = Environment.GetEnvironmentVariable("IDENTITY_CLIENT_ID"),
        ClientSecret = Environment.GetEnvironmentVariable("IDENTITY_CLIENT_SECRET"),
#endif
        AppName = "eWAN WebApis",
    };
});

app.Run();