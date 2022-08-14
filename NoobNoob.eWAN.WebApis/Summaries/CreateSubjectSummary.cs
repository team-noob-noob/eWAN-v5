using System.Net;
using FastEndpoints;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.WebApis.Endpoints;

namespace NoobNoob.eWAN.WebApis.Summaries;

public class CreateSubjectSummary : Summary<CreateSubjectEndpoint>
{
    public CreateSubjectSummary()
    {
        Summary = "Creates a new Subject";
        Description = "Creates a new Subject in the System";
        Response<CreateSubjectResponse>((int)HttpStatusCode.Created, "Subject was created");
        Response<ValidationFailureResponse>((int)HttpStatusCode.BadRequest, "The request did not pass validation checks");
    }
}