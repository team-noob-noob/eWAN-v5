using Microsoft.EntityFrameworkCore;
using NoobNoob.eWAN.Application.Contracts.Data;

namespace NoobNoob.eWAN.Infrastructure.Data.EfCoreCosmos;

public class EwanCosmosDbContext : DbContext
{
    public DbSet<SubjectDto> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            Environment.GetEnvironmentVariable("AZURE_COSMOS_CONNECTIONSTRING"),
            "ewan");
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }
}