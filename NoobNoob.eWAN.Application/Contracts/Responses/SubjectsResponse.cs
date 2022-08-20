using NoobNoob.eWAN.Application.Contracts.Data;

namespace NoobNoob.eWAN.Application.Contracts.Responses;

public class SubjectsResponse
{
    public IEnumerable<SubjectDto> Subjects { get; init; } = default!;
}