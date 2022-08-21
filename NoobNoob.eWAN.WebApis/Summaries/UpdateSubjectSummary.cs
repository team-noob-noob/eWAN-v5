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
        Summary = "Creates a new Subject";
        Description = "Creates a new Subject in the System";
        Response<SubjectDto>((int)HttpStatusCode.OK, "Subject was created");
        Response<ValidationFailureResponse>((int)HttpStatusCode.BadRequest, "The request did not pass validation checks");
    }
}