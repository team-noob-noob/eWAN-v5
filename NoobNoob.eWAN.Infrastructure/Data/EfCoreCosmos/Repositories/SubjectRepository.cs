using Microsoft.EntityFrameworkCore;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Interfaces.Repositories;

namespace NoobNoob.eWAN.Infrastructure.Data.EfCoreCosmos.Repositories;

/// <summary>
/// EF Core and Cosmos implementation of the <see cref="ISubjectRepository"/> interface.
/// </summary>
public class SubjectRepository : ISubjectRepository
{
    public SubjectRepository(EwanCosmosDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    private readonly EwanCosmosDbContext _dbContext;
    
    public async Task<bool> AddSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken))
        => (await _dbContext.Subjects.AddAsync(subject, cancellationToken)).State == EntityState.Added;

    public async Task<bool> UpdateSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken))
        => _dbContext.Subjects.Update(subject).State == EntityState.Modified;

    public async Task<bool> DeleteSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken))
        => _dbContext.Subjects.Remove(subject).State == EntityState.Deleted;

    public async Task<SubjectDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.Subjects.FindAsync(id, cancellationToken);

    public async Task<SubjectDto?> GetByCodeAsync(string code, CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Code == code, cancellationToken: cancellationToken);

    public async Task<SubjectDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Title == title, cancellationToken: cancellationToken);
}