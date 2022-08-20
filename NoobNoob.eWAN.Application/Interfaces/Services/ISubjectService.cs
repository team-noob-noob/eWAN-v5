using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Core.Entities;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.Application.Interfaces.Services;

/// <summary>
/// Interface for the service that handles the management of Subjects.
/// </summary>
public interface ISubjectService
{
    /// <summary>
    /// Creates a new subject.
    /// </summary>
    /// <param name="subject">The subject that needs to be created</param>
    /// <returns>True if the subject was created, false otherwise</returns>
    Task<bool> CreateSubject(Subject subject);

    /// <summary>
    /// Updates an existing subject.
    /// </summary>
    /// <param name="subject">The updated subject that needs to be stored</param>
    /// <returns>True if the subject was updated, false otherwise</returns>
    Task<bool> UpdateSubject(Subject subject);

    /// <summary>
    /// Marks the Subject as deleted
    /// </summary>
    /// <param name="subject">The Subject that needs to be deleted</param>
    /// <returns>True if the subject was deleted, false otherwise</returns>
    Task<bool> DeleteSubject(Subject subject);
    
    /// <summary>
    /// Get subject by id
    /// </summary>
    /// <param name="id">The id of the subject</param>
    /// <returns>Either returns null or the subject that matches the id</returns>
    Task<Subject?> GetSubjectById(SubjectId id);
    
    /// <summary>
    /// Get subject by code
    /// </summary>
    /// <param name="code">The code of the subject</param>
    /// <returns>Either returns null or the subject that matches the code</returns>
    Task<Subject?> GetSubjectByCode(string code);
    
    /// <summary>
    /// Get subject by title
    /// </summary>
    /// <param name="title">The title of the subject</param>
    /// <returns>Either returns null or the subject that matches the code</returns>
    Task<Subject?> GetSubjectByTitle(string title, CancellationToken cancellationToken = default(CancellationToken));
}