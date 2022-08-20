using NoobNoob.eWAN.Application.Enums;

namespace NoobNoob.eWAN.Application.Contracts.Requests.Common;

public class Query
{
    public string? SortBy { get; init; } = default!;
    public SortDirection? SortOrder { get; init; } = SortDirection.Ascending;
    public string? Title { get; init; } = default!;
    public int? PageSize { get; init; } = 10;
    public int? PageNumber { get; init; } = 1;
}