namespace OrderService.Application.Services.Dto;

public class CreateOrderRequest
{
    public string Description { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}