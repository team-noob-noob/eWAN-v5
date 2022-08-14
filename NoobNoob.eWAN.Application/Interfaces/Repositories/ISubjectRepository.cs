using NoobNoob.eWAN.Application.Contracts.Data;
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
    /// <returns>True if the subject is added successfully, false otherwise</returns>
    Task<bool> AddSubject(SubjectDto subject);
    
    /// <summary>
    /// Updates the subject 
    /// </summary>
    /// <param name="subject">The updated subject</param>
    /// <returns>True if the subject is updated, false otherwise</returns>
    Task<bool> UpdateSubject(SubjectDto subject);
    
    /// <summary>
    /// Marks the subject as deleted
    /// </summary>
    /// <param name="subject">The subject that needs to be deleted</param>
    /// <returns>True if the subject is deleted, false otherwise</returns>
    Task<bool> DeleteSubject(SubjectDto subject);
    
    /// <summary>
    /// Fetches a subject from the repository by its id.
    /// </summary>
    /// <param name="id">The id of the subject</param>
    /// <returns>The Subject if there's match</returns>
    Task<SubjectDto?> GetById(Guid id);
    
    /// <summary>
    /// Fetches a subject from the repository by its code.
    /// </summary>
    /// <param name="code">The short name of the subject</param>
    /// <returns>The Subject if there's a match</returns>
    Task<SubjectDto?> GetByCode(string code);
    
    /// <summary>
    /// Fetches a subject from the repository by its name.
    /// </summary>
    /// <param name="title">The title of the subject</param>
    /// <returns>The Subject if there's a match</returns>
    Task<SubjectDto?> GetByTitle(string title);
}