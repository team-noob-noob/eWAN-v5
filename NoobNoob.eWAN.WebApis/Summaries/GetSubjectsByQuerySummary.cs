using System.Net;
using FastEndpoints;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.WebApis.Endpoints;

namespace NoobNoob.eWAN.WebApis.Summaries;

public class GetSubjectsByQuerySummary : Summary<GetSubjectsByQueryEndpoint>
{
    public GetSubjectsByQuerySummary()
    {
        Summary = "Get subjects by query";
        Description = "Get subjects by query";
        Response<IEnumerable<SubjectDto>>((int)HttpStatusCode.OK, "The subjects that matches the query");
        Response<ValidationFailureResponse>((int)HttpStatusCode.BadRequest, "The request did not pass validation checks");
    }
}