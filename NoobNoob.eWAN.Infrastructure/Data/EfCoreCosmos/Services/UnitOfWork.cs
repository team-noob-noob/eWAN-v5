using NoobNoob.eWAN.Application.Interfaces.Services;

namespace NoobNoob.eWAN.Infrastructure.Data.EfCoreCosmos.Services;

/// <summary>
/// EF Core and Cosmos implementation of the <see cref="IUnitOfWork"/> interface.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(EwanCosmosDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    private readonly EwanCosmosDbContext _dbContext;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.SaveChangesAsync(cancellationToken);
}