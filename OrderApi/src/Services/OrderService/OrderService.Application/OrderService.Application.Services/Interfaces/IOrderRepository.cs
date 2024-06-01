using OrderService.Application.Services.Dto;
using OrderService.Domain.Entities;

namespace OrderService.Application.Services.Interfaces;

public interface IOrderRepository
{
    Task<Order[]> GetOrdersAsync(GetOrdersRequest request, CancellationToken cancellationToken = default);
    Task<Order?> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<Guid> AddOrderAsync(Order order, CancellationToken cancellationToken = default);
    void Delete(Order order);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}