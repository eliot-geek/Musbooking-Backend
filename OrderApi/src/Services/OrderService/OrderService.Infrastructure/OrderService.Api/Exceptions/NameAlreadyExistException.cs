using ExceptionsLibrary.Exceptions;

namespace OrderService.Api.Exceptions;

[Serializable]
public class NameAlreadyExistException : AlreadyExistException
{
    public NameAlreadyExistException()
    {
    }

    public NameAlreadyExistException(string message) : base(message)
    {
    }

    public NameAlreadyExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}