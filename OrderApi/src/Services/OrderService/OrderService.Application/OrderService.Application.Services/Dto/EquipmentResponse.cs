namespace OrderService.Application.Services.Dto;

public class EquipmentResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Amount { get; init; }
    public double Price { get; init; }
}