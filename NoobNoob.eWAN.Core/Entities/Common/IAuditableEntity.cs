namespace NoobNoob.eWAN.Core.Entities.Common;

/// <summary>
/// Defines properties used for entities that needs to have auditable properties.
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// The date and time the entity was created
    /// </summary>
    DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// The date and time the entity was deleted
    /// </summary>
    /// <remarks>
    /// If the property is null, then the property is not deleted
    /// </remarks>
    DateTime? DeletedAt { get; set; }

    /// <summary>
    /// The date and time the entity was updated
    /// </summary>
    DateTime? UpdatedAt { get; set; }
}