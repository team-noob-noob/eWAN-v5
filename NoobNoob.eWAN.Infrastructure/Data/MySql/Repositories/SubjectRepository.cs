using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Requests.Common;
using NoobNoob.eWAN.Application.Enums;
using NoobNoob.eWAN.Application.Interfaces.Repositories;

namespace NoobNoob.eWAN.Infrastructure.Data.MySql.Repositories;

/// <summary>
/// EF Core and MySql implementation of the <see cref="ISubjectRepository"/> interface.
/// </summary>
public class SubjectRepository : ISubjectRepository
{
    public SubjectRepository(EwanMysqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }
 
    private readonly EwanMysqlDbContext _dbContext;

    public async Task<bool> AddSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken))
        => (await _dbContext.Subjects.AddAsync(subject, cancellationToken)).State == EntityState.Added;

    public async Task<bool> UpdateSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken))
        => _dbContext.Subjects.Update(subject).State == EntityState.Modified;

    public async Task<bool> DeleteSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken))
        => _dbContext.Subjects.Remove(subject).State == EntityState.Deleted;

    public async Task<SubjectDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.Subjects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<SubjectDto?> GetByCodeAsync(string code, CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.Subjects.AsNoTracking().FirstOrDefaultAsync(x => x.Code == code, cancellationToken: cancellationToken);

    public async Task<SubjectDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default(CancellationToken))
        => await _dbContext.Subjects.AsNoTracking().FirstOrDefaultAsync(x => x.Title == title, cancellationToken: cancellationToken);

    public async Task<IEnumerable<SubjectDto>> GetByQueryAsync(Query query,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var orderingQuery = query.SortOrder == SortDirection.Ascending ? query.SortBy : $"{query.SortBy} desc";
        var orderedSubjects = _dbContext.Subjects.AsNoTracking().OrderBy(orderingQuery);

        if (query.Title is null)
            return orderedSubjects.Skip((query.PageNumber.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value);

        var filteredByTitle = orderedSubjects.Where(x => x.Title.Contains(query.Title));
        return filteredByTitle.Skip((query.PageNumber.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value);
    }
}
