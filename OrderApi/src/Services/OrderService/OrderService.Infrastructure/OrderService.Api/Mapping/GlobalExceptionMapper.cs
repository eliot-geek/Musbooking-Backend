using ExceptionsLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OrderService.Api.Exceptions;
using OrderService.Api.Primitives;

namespace OrderService.Api.Mapping;

public class GlobalExceptionMapper : IGlobalExceptionMapper
{
    public Exception Map(Exception ex)
    {
        return ex switch
        {
            DbUpdateException
            {
                InnerException: PostgresException { SqlState: PostgresErrorCodes.UniqueViolation } postgresException
            } => postgresException.ConstraintName switch
            {
              IndexNames.EquipmentNameIndex => new NameAlreadyExistException(ExceptionMessages.EquipmentNameAlreadyExistException),
                _ => ex
            },
            _ => ex
        };
    }
}