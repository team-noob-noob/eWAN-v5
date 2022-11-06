using Duende.IdentityServer;
using NoobNoob.eWAN.IdentityServer;
using NoobNoob.eWAN.IdentityServer.Pages.Admin.ApiScopes;
using NoobNoob.eWAN.IdentityServer.Pages.Admin.Clients;
using NoobNoob.eWAN.IdentityServer.Pages.Admin.IdentityScopes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Serilog;
using Microsoft.Extensions.Options;

namespace NoobNoob.eWAN.IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
#if DEBUG
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
#else
                policy.WithOrigins(Environment.GetEnvironmentVariable("CORS_ORIGIN"))
                    .AllowAnyHeader()
                    .AllowAnyMethod();
#endif
            });
        });


        var connectionString = Environment.GetEnvironmentVariable("AZURE_COSMOS_CONNECTIONSTRING") ?? "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        var isBuilder = builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
#if DEBUG
            .AddTestUsers(TestUsers.Users)
#endif
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseCosmos(connectionString, "ewan");
            })
            .AddConfigurationStoreCache()
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseCosmos(connectionString, "ewan");
                
                // this enables automatic token cleanup. this is optional.
                options.EnableTokenCleanup = true;
                options.RemoveConsumedTokens = true;
            });

        builder.Services.AddAuthentication();

        builder.Services.AddAuthorization(options =>
            options.AddPolicy("admin",
                policy => policy.RequireClaim("sub", "1"))
        );

        builder.Services.Configure<RazorPagesOptions>(options =>
            options.Conventions.AuthorizeFolder("/Admin", "admin"));

        builder.Services.AddTransient<ClientRepository>();
        builder.Services.AddTransient<IdentityScopeRepository>();
        builder.Services.AddTransient<ApiScopeRepository>();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors();

        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();

        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}