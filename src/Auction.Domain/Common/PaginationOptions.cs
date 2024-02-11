namespace Auction.Domain.Common;

public record PaginationOptions
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 10;

    public int Page { get; init; } = DefaultPage;
    public int PageSize { get; init; } = DefaultPageSize;
}