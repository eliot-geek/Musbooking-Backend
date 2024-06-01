namespace OrderService.Application.Services.Dto;

public class GetOrdersRequest : BasePaginationRequest
{
    public bool IsDesc { get; init; }
}