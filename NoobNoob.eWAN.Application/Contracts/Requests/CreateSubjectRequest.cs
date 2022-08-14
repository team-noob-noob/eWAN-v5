namespace NoobNoob.eWAN.Application.Contracts.Requests;

public class CreateSubjectRequest
{
    public string Code { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
}