namespace OrderService.Application.Services.Dto;

public class UpdateOrderRequest
{
    public Guid Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime UpdatedAt { get; init; }
}