using Ardalis.GuardClauses;
using AutoMapper;
using OrderService.Application.Services.Dto;
using OrderService.Application.Services.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Domain.Exceptions;
using OrderService.Domain.Extensions;
using OrderService.Domain.Primitives;

namespace OrderService.Application.Services.Services;

public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public async Task<OrderResponse[]> GetOrdersAsync(GetOrdersRequest request, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(request, nameof(request));

        var orders = await orderRepository.GetOrdersAsync(request, cancellationToken);
        return mapper.Map<OrderResponse[]>(orders);
    }

    public async Task<OrderResponse> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        Guard.Against.IsGuidEmpty(orderId, nameof(orderId));

        var order = await orderRepository.GetOrderByIdAsync(orderId, cancellationToken) ??
                    throw new EntityNotFoundException(string.Format(ExceptionMessages.OrderNotFound, nameof(orderId)));

        return mapper.Map<OrderResponse>(order);
    }

    public async Task<Guid> CreateOrderAsync(CreateOrderRequest request, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(request, nameof(request));

        var order = new Order(Guid.NewGuid(), request.Description, request.CreatedAt);

        var orderId = await orderRepository.AddOrderAsync(order, cancellationToken);

        await orderRepository.SaveChangesAsync(cancellationToken);
        return orderId;
    }

    public async Task<Guid> AddEquipmentAsync(CreateEquipmentRequest request, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(request, nameof(request));
        var equipmentId = Guid.NewGuid();
        var order = await orderRepository.GetOrderByIdAsync(request.OrderId, cancellationToken) ??
                    throw new EntityNotFoundException(string.Format(ExceptionMessages.OrderNotFound, nameof(request.OrderId)));

        order.AddEquipment(equipmentId, request.Name, request.Amount, request.Price);

        await orderRepository.SaveChangesAsync(cancellationToken);
        return equipmentId;
    }

    public async Task<Guid> UpdateOrderAsync(UpdateOrderRequest request, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(request, nameof(request));
        Guard.Against.IsGuidEmpty(request.Id, nameof(request.Id));

        var order = await orderRepository.GetOrderByIdAsync(request.Id, cancellationToken) ??
                    throw new EntityNotFoundException(string.Format(ExceptionMessages.OrderNotFound, nameof(request.Id)));

        order.Update(request.Description, request.UpdatedAt);

        await orderRepository.SaveChangesAsync(cancellationToken);

        return order.Id;
    }

    public async Task DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        Guard.Against.Default(orderId);

        var order = await orderRepository.GetOrderByIdAsync(orderId, cancellationToken) ??
                    throw new EntityNotFoundException(string.Format(ExceptionMessages.OrderNotFound, nameof(orderId)));

        orderRepository.Delete(order);

        await orderRepository.SaveChangesAsync(cancellationToken);
    }
}