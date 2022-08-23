using System.Net;
using FastEndpoints;
using NoobNoob.eWAN.Application.Contracts.Responses;
using NoobNoob.eWAN.WebApis.Endpoints;

namespace NoobNoob.eWAN.WebApis.Summaries;

public class DeleteSubjectByIdSummary : Summary<DeleteSubjectByIdEndpoint>
{
    public DeleteSubjectByIdSummary()
    {
        Summary = "Deletes a Subject";
        Description = "Deletes a Subject in the System";
        Response((int)HttpStatusCode.OK, "Subject was deleted");
        Response<ValidationFailureResponse>((int)HttpStatusCode.BadRequest, "The request did not pass validation checks");
    }
}