using NoobNoob.eWAN.Application.Interfaces.Services;

namespace NoobNoob.eWAN.Infrastructure.Data.MySql.Services;

/// <summary>
/// EF Core and MySql implementation of the <see cref="IUnitOfWork"/> interface.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(EwanMysqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly EwanMysqlDbContext _dbContext;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.SaveChangesAsync(cancellationToken);
}
