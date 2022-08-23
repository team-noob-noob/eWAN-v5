using System.Net;
using FastEndpoints;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.WebApis.Endpoints;

namespace NoobNoob.eWAN.WebApis.Summaries;

public class UpdateSubjectSummary : Summary<UpdateSubjectEndpoint>
{
    public UpdateSubjectSummary()
    {
        Summary = "Updates a Subject";
        Description = "Updates a Subject in the System";
        Response<SubjectDto>((int)HttpStatusCode.OK, "Subject was updated");
        Response<ValidationFailureResponse>((int)HttpStatusCode.BadRequest, "The request did not pass validation checks");
    }
}