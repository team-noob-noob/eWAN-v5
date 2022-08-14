using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Requests;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Mappings;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.WebApis.Endpoints;

[HttpGet("/subjects/FindById/{id:guid}"), AllowAnonymous]
public class GetSubjectByIdEndpoint : Endpoint<GetSubjectByIdRequest, SubjectDto>
{
    public GetSubjectByIdEndpoint(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    private readonly ISubjectService _subjectService;


    public override async Task HandleAsync(GetSubjectByIdRequest req, CancellationToken ct)
    {
        var subject = await _subjectService.GetSubjectById(SubjectId.From(req.Id));

        if (subject is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var response = subject.ToSubjectDto();

        await SendOkAsync(response, ct);
    }
}