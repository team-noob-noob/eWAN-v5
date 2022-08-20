using NoobNoob.eWAN.Application.Contracts.Requests.Common;

namespace NoobNoob.eWAN.Application.Contracts.Requests;

public class SubjectQueryRequest : Query
{
    public SubjectQueryRequest()
    {
        SortBy = "Title";
    }
}