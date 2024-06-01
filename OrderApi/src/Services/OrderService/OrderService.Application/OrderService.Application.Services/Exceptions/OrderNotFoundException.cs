using ExceptionsLibrary.Exceptions;

namespace OrderService.Application.Services.Exceptions;

public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException()
    {
    }

    public OrderNotFoundException(string message) : base(message)
    {
    }

    public OrderNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}