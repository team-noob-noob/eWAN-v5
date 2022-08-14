using NoobNoob.eWAN.Core.Entities.Common;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.Core.Entities;

/// <summary>
/// Represents the topic in a Learning Organization
/// </summary>
public class Subject : IAuditableEntity
{
    /// <summary>
    /// Id of the Subject; Subject ID
    /// </summary>
    public SubjectId Id { get; init; } = SubjectId.From(Guid.NewGuid());

    /// <summary>
    /// A short name for the Subject
    /// </summary>
    public string Code { get; init; } = default!;
    
    /// <summary>
    /// Title or name of the subject
    /// </summary>
    public string Title { get; init; } = default!;

    /// <summary>
    /// Description of the subject
    /// </summary>
    public MarkdownString Description { get; init; } = default!;

    /// <summary>
    /// Subjects the student must pass before taking this subject
    /// </summary>
    public List<Subject> Prerequisites { get; init; } = new List<Subject>();

    /// <inheritdoc cref="IAuditableEntity.CreatedAt"/>
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    
    /// <inheritdoc cref="IAuditableEntity.DeletedAt"/>
    public DateTime? DeletedAt { get; set; }
    
    /// <inheritdoc cref="IAuditableEntity.UpdatedAt"/>
    public DateTime? UpdatedAt { get; set; }
}