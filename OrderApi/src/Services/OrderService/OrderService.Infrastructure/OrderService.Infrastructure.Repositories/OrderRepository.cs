using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Services.Dto;
using OrderService.Application.Services.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Domain.Extensions;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
    public async Task<Order[]> GetOrdersAsync(GetOrdersRequest request, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(request, nameof(request));

        var query = context.Orders.AsNoTracking().AsQueryable();
        return request.IsDesc
            ? await query.Skip(request.Skip).Take(request.Take).OrderByDescending(c => c.CreatedDate.CreatedAt)
                .ToArrayAsync(cancellationToken)
            : await query.Skip(request.Skip).Take(request.Take).OrderBy(c => c.CreatedDate.CreatedAt)
                .ToArrayAsync(cancellationToken);
    }

    public async Task<Order?> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        Guard.Against.IsGuidEmpty(orderId, nameof(orderId));

        return await context.Orders.Include(w => w.Equipments).FirstOrDefaultAsync(p => p.Id == orderId, cancellationToken);
    }

    public async Task<Guid> AddOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(order, nameof(order));

        await context.Orders.AddAsync(order, cancellationToken);
        return order.Id;
    }

    public void Delete(Order order)
    {
        Guard.Against.Null(order, nameof(order));

        context.Orders.Remove(order);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}