using Microsoft.EntityFrameworkCore;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobNoob.eWAN.Infrastructure.Data.MySql;
public class EwanMysqlDbContext : DbContext
{
    public DbSet<SubjectDto> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("AZURE_MYSQL_CONNECTIONSTRING");
        optionsBuilder.UseMySql(ServerVersion.AutoDetect(connectionString));
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
