using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Requests;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.Core.Entities;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.Application.Mappings;

/// <summary>
/// Contains mappings for <see cref="Subject"/>
/// </summary>
public static class SubjectExtensions
{
    /// <summary>
    /// Converts a <see cref="Subject"/> to a <see cref="CreateSubjectResponse"/>.
    /// </summary>
    /// <param name="subject">The <see cref="Subject"/> instance that will be converted</param>
    /// <returns>The new <see cref="CreateSubjectResponse"/> created</returns>
    public static CreateSubjectResponse ToCreateSubjectResponse(this Subject subject)
        => new()
        {
            Id = subject.Id.Value,
            Code = subject.Code,
            Title = subject.Title,
            Description = subject.Description.Value,
            CreatedAt = subject.CreatedAt,
        };

    /// <summary>
    /// Converts a <see cref="Subject"/> to a <see cref="SubjectDto"/>.
    /// </summary>
    /// <param name="subject">The <see cref="Subject"/> instance that will be converted</param>
    /// <returns>The new <see cref="SubjectDto"/> created</returns>
    public static SubjectDto ToSubjectDto(this Subject subject)
        => new()
        {
            Id = subject.Id.Value,
            Code = subject.Code,
            Title = subject.Title,
            Description = subject.Description.Value,
            CreatedAt = subject.CreatedAt,
            UpdatedAt = subject.UpdatedAt,
            DeletedAt = subject.DeletedAt,
        };
}

/// <summary>
/// Contains mappings for <see cref="SubjectDto"/>
/// </summary>
public static class SubjectDtoExtensions
{
    /// <summary>
    /// Converts a <see cref="SubjectDto"/> to a <see cref="Subject"/>.
    /// </summary>
    /// <param name="subjectDto">The <see cref="SubjectDto"/> instance that will be converted</param>
    /// <returns>The new <see cref="Subject"/> created</returns>
    public static Subject ToSubject(this SubjectDto subjectDto)
        => new()
        {
            Id = SubjectId.From(subjectDto.Id),
            Code = subjectDto.Code,
            Title = subjectDto.Title,
            Description = MarkdownString.From(subjectDto.Description),
            CreatedAt = subjectDto.CreatedAt,
            UpdatedAt = subjectDto.UpdatedAt,
            DeletedAt = subjectDto.DeletedAt,
        };
}

/// <summary>
/// Contains mappings for <see cref="CreateSubjectRequest"/>
/// </summary>
public static class CreateSubjectRequestExtensions
{
    /// <summary>
    /// Converts a <see cref="CreateSubjectRequest"/> to a <see cref="Subject"/>.
    /// </summary>
    /// <param name="subject">The <see cref="CreateSubjectRequest"/> instance that will be converted</param>
    /// <returns>The new <see cref="Subject"/> created</returns>
    public static Subject ToSubject(this CreateSubjectRequest subject)
        => new()
        {
            Code = subject.Code,
            Title = subject.Title,
            Description = MarkdownString.From(subject.Description),
        };
}

public static class UpdateSubjectRequestExtensions
{
    public static Subject ToSubject(this UpdateSubjectRequest subject, Subject existingSubject)
        => new()
        {
            Id = existingSubject.Id,
            Code = subject.Code ?? existingSubject.Code,
            Title = subject.Title ?? existingSubject.Title,
            Description = subject.Description is not null ? MarkdownString.From(subject.Description) : existingSubject.Description,
            CreatedAt = existingSubject.CreatedAt,
            UpdatedAt = DateTime.Now,
            DeletedAt = existingSubject.DeletedAt,
        };
}
