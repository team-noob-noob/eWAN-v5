using NoobNoob.eWAN.Core.Entities.Common;

namespace NoobNoob.eWAN.Application.Contracts.Data;

/// <summary>
/// Simplified definition of <see cref="NoobNoob.eWAN.Core.Entities.Subject"/>
/// </summary>
public class SubjectDto : IAuditableEntity
{
    /// <summary>
    /// Id of the Subject
    /// </summary>
    public Guid Id { get; init; } = default!;

    public Guid Guid { get; init; } = Guid.NewGuid();
    
    /// <summary>
    /// Short of the Subject
    /// </summary>
    public string Code { get; init; } = default!;
    
    /// <summary>
    /// Name/Title of the Subject
    /// </summary>
    public string Title { get; init; } = default!;

    /// <summary>
    /// Description of the Subject
    /// </summary>
    public string Description { get; init; } = default!;
    
    public DateTime CreatedAt { get; init; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}