using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using NoobNoob.eWAN.Application.Contracts.Requests;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.Application.Interfaces.Repositories;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Mappings;

namespace NoobNoob.eWAN.WebApis.Endpoints;

[HttpGet("/subjects"), AllowAnonymous]
public class GetSubjectsByQueryEndpoint : Endpoint<SubjectQueryRequest, SubjectsResponse>
{
    public GetSubjectsByQueryEndpoint(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }    
    
    private readonly ISubjectService _subjectService;

    public override async Task HandleAsync(SubjectQueryRequest req, CancellationToken ct)
    {
        var subjects = await _subjectService.GetSubjectsByQueryAsync(req, ct);

        var response = new SubjectsResponse()
        {
            Subjects = subjects.Select(x => x.ToSubjectDto()),
        };

        await SendOkAsync(response, ct);
    }
}