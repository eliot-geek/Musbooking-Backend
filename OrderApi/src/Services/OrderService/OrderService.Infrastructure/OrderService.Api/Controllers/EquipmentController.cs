using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Services.Dto;
using OrderService.Application.Services.Interfaces;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController(IOrderService orderService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateEquipmentRequest request)
    {
        Guard.Against.Null(request, nameof(request));
        var equipmentId = await orderService.AddEquipmentAsync(request);
        return Ok(equipmentId);
    }
}