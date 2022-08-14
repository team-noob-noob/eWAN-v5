using System.Net;
using FastEndpoints;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.WebApis.Endpoints;

namespace NoobNoob.eWAN.WebApis.Summaries;

public class GetSubjectByIdSummary : Summary<GetSubjectByIdEndpoint>
{
    public GetSubjectByIdSummary()
    {
        Summary = "Fetch a Subject by id";
        Description = "Fetches a subject that matches the given id";
        Response<SubjectDto>((int)HttpStatusCode.OK, "The subject was found");
        Response((int)HttpStatusCode.NotFound, "The subject was not found");
        Response<ValidationFailureResponse>((int)HttpStatusCode.BadRequest, "The request did not pass validation checks");
    }
}