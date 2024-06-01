namespace OrderService.Application.Services.Dto;

public class PaginationResponse<T> where T : class
{
    public int ItemCount { get; init; }
    public T[] Items { get; init; } = Array.Empty<T>();
}