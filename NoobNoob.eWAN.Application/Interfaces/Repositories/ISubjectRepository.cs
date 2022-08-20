using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Requests;
using NoobNoob.eWAN.Application.Contracts.Requests.Common;
using NoobNoob.eWAN.Core.Entities;

namespace NoobNoob.eWAN.Application.Interfaces.Repositories;

/// <summary>
/// Defines the queries for the Subject repository.
/// </summary>
public interface ISubjectRepository
{
    /// <summary>
    /// Adds the specified subject into the repository.
    /// </summary>
    /// <param name="subject">The subject that needs to be added</param>
    /// <param name="cancellationToken">Optional, Cancellation Token</param>
    /// <returns>True if the subject is added successfully, false otherwise</returns>
    Task<bool> AddSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Updates the subject 
    /// </summary>
    /// <param name="subject">The updated subject</param>
    /// <param name="cancellationToken"></param>
    /// <returns>True if the subject is updated, false otherwise</returns>
    Task<bool> UpdateSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Marks the subject as deleted
    /// </summary>
    /// <param name="subject">The subject that needs to be deleted</param>
    /// <param name="cancellationToken">Optional, Cancellation Token</param>
    /// <returns>True if the subject is deleted, false otherwise</returns>
    Task<bool> DeleteSubjectAsync(SubjectDto subject, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Fetches a subject from the repository by its id.
    /// </summary>
    /// <param name="id">The id of the subject</param>
    /// <param name="cancellationToken">Optional, Cancellation Token</param>
    /// <returns>The Subject if there's match</returns>
    Task<SubjectDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Fetches a subject from the repository by its code.
    /// </summary>
    /// <param name="code">The short name of the subject</param>
    /// <param name="cancellationToken">Optional, Cancellation Token</param>
    /// <returns>The Subject if there's a match</returns>
    Task<SubjectDto?> GetByCodeAsync(string code, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Fetches a subject from the repository by its name.
    /// </summary>
    /// <param name="title">The title of the subject</param>
    /// <param name="cancellationToken">Optional, Cancellation Token</param>
    /// <returns>The Subject if there's a match</returns>
    Task<SubjectDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default(CancellationToken));
    
    /// <summary>
    /// Fetches a list subjects based on the given query
    /// </summary>
    /// <param name="query">The filters and ordering that needs to be followed</param>
    /// <param name="cancellationToken">Optional, Cancellation token</param>
    /// <returns>The list of subjects that matches the given query</returns>
    Task<IEnumerable<SubjectDto>> GetByQueryAsync(Query query,
        CancellationToken cancellationToken = default(CancellationToken));
}