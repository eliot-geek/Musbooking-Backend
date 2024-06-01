using System.Collections;

namespace ExceptionsLibrary.Dto;


public class ErrorResponse
{
    
    public string Message { get; set; } = string.Empty;

    
    public string ExceptionType { get; set; } = null!;

    
    public IDictionary Data { get; set; } = null!;

    
    public string? StackTrace { get; set; }
}