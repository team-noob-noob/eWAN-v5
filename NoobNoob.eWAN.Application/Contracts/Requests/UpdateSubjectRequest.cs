namespace NoobNoob.eWAN.Application.Contracts.Requests;

public class UpdateSubjectRequest
{
    public Guid Id { get; init; }
    public string? Code { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
}