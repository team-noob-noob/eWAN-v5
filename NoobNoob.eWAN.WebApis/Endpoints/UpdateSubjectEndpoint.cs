using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Requests;
using NoobNoob.eWAN.Application.Interfaces.Services;
using NoobNoob.eWAN.Application.Mappings;
using NoobNoob.eWAN.Core.ValueObjects;

namespace NoobNoob.eWAN.WebApis.Endpoints;

[HttpPut("subjects/{Id}")]
public class UpdateSubjectEndpoint : Endpoint<UpdateSubjectRequest, SubjectDto>
{
    public UpdateSubjectEndpoint(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    
    private readonly ISubjectService _subjectService;

    public override async Task HandleAsync(UpdateSubjectRequest req, CancellationToken ct)
    {
        var existingSubject = await _subjectService.GetSubjectByIdAsync(SubjectId.From(req.Id), ct);

        if (existingSubject is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        var updatedSubject = req.ToSubject(existingSubject);
        
        await _subjectService.UpdateSubjectAsync(updatedSubject, ct);

        var response = updatedSubject.ToSubjectDto();

        await SendOkAsync(response, ct);
    }
}