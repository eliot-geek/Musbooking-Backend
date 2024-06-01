namespace OrderService.Application.Services.Dto;

public class CreateEquipmentRequest
{
    public Guid OrderId { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Amount { get; init; }
    public double Price { get; init; }
}