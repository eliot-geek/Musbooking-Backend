namespace OrderService.Application.Services.Dto;

public class OrderResponse
{
    public Guid Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public double Price { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}