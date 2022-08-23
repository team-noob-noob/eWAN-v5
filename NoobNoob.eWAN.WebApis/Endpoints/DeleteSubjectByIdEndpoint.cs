using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Requests;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.WebApis.Endpoints;

[HttpDelete("/subjects/{Id}"), AllowAnonymous]
public class DeleteSubjectByIdEndpoint : Endpoint<DeleteSubjectByIdRequest, SubjectDto>
{
    public DeleteSubjectByIdEndpoint(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    
    private readonly ISubjectService _subjectService;

    public override async Task HandleAsync(DeleteSubjectByIdRequest req, CancellationToken ct)
    {
        var subjectToBeDeleted = await _subjectService.GetSubjectByIdAsync(SubjectId.From(req.Id), ct);

        if (subjectToBeDeleted is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await _subjectService.DeleteSubjectAsync(subjectToBeDeleted, ct);
        
        await SendOkAsync(ct);
    }
}