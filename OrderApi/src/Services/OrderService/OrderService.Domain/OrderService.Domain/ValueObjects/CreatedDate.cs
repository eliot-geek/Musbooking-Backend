using Ardalis.GuardClauses;

namespace OrderService.Domain.ValueObjects;

public class CreatedDate
{
    public DateTime CreatedAt { get; init; }

    public CreatedDate(DateTime createdAt)
    {
        Guard.Against.Default(createdAt, nameof(createdAt));
        CreatedAt = createdAt;
    }
}