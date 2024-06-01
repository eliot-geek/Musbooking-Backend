namespace OrderService.Application.Services.Dto;

public class BasePaginationRequest
{
    public int Skip { get; init; }
    public int Take { get; init; }
}