using NoobNoob.eWAN.Application.Contracts.Data;

namespace NoobNoob.eWAN.Application.Contracts.Responses;

public class CreateSubjectResponse 
{
    public Guid Id { get; init; } = default!;

    public string Code { get; init; } = default!;
    
    public string Title { get; init; } = default!;
    
    public string Description { get; init; } = default!;

    public DateTime CreatedAt { get; init; } = default!;
}