using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using NoobNoob.eWAN.Application.Contracts.Requests;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Mappings;

namespace NoobNoob.eWAN.WebApis.Endpoints;

[HttpPost("/subjects"), AllowAnonymous]
public class CreateSubjectEndpoint : Endpoint<CreateSubjectRequest, CreateSubjectResponse>
{
    public CreateSubjectEndpoint(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    
    private readonly ISubjectService _subjectService;

    public override async Task HandleAsync(CreateSubjectRequest req, CancellationToken ct)
    {
        var subject = req.ToSubject();
        
        await _subjectService.CreateSubject(subject, ct);

        var response = subject.ToCreateSubjectResponse();

        await SendCreatedAtAsync<GetSubjectByIdEndpoint>(
            new {response.Id},
            response,
            generateAbsoluteUrl: true,
            cancellation: ct);
    }
}