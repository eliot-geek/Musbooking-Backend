using OrderService.Application.Services.Dto;

namespace OrderService.Application.Services.Interfaces;

public interface IOrderService
{
    Task<OrderResponse[]> GetOrdersAsync(GetOrdersRequest request, CancellationToken cancellationToken = default);
    Task<OrderResponse> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<Guid> CreateOrderAsync(CreateOrderRequest request, CancellationToken cancellationToken = default);
    Task<Guid> AddEquipmentAsync(CreateEquipmentRequest request, CancellationToken cancellationToken = default);
    Task<Guid> UpdateOrderAsync(UpdateOrderRequest updateOrderRequest, CancellationToken cancellationToken = default);
    Task DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
}