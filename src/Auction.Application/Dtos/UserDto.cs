namespace Auction.Application.Dtos;

public record UserDto : EntityDto<Guid>
{
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public Uri? Avatar { get; init; }
}