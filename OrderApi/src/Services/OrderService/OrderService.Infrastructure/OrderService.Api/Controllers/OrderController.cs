using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Services.Dto;
using OrderService.Application.Services.Interfaces;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet("orders")]
    public async Task<ActionResult> Get([FromQuery] GetOrdersRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var order = await orderService.GetOrdersAsync(request);
        return Ok(order);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] CreateOrderRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var orderId = await orderService.CreateOrderAsync(request);
        return Ok(orderId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateOrderRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var updatedOrderId = await orderService.UpdateOrderAsync(request);
        return Ok(updatedOrderId);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        Guard.Against.Default(id, nameof(id));

        await orderService.DeleteOrderAsync(id);
        return NoContent();
    }
}