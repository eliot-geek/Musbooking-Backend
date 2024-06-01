using ExceptionsLibrary.Exceptions;

namespace OrderService.Domain.Exceptions;

[Serializable]
public class EntityNotFoundException : NotFoundException
{
    public EntityNotFoundException()
    {
    }

    public EntityNotFoundException(string message) : base(message)
    {
    }

    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}