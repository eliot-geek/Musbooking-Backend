using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using OrderService.Domain.Entities;
using OrderService.Domain.Exceptions;
using OrderService.Domain.Primitives;

namespace OrderService.Domain.Extensions;

public static class GuardExtension
{
    private const int MaxAge = 120;

    public static void IsLetters(this IGuardClause guardClause, string input, string parameterName)
    {
        Guard.Against.NullOrWhiteSpace(input, parameterName);
        if (!Regex.IsMatch(input, RegexPatterns.IsLetters))
        {
            throw new ArgumentException(string.Format(ExceptionMessages.IsLettersFormatException, input,
                parameterName));
        }
    }

    public static void MinStringLength(this IGuardClause guardClause, string input, int minimalSize,
        string parameterName)
    {
        Guard.Against.NullOrWhiteSpace(input, parameterName);
        if (input.Length < minimalSize)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.StrOutOfRangeException, input, parameterName));
        }
    }

    public static void MaxStringLength(this IGuardClause guardClause, string input, int maxSize, string parameterName)
    {
        Guard.Against.NullOrWhiteSpace(input, parameterName);
        if (input.Length > maxSize)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.StrOutOfRangeException, input, parameterName));
        }
    }

    public static void IsGuidEmpty(this IGuardClause guardClause, Guid input, string parameterName)
    {
        guardClause.Default(input, nameof(input));
        guardClause.NullOrEmpty(parameterName, nameof(parameterName));
        if (input == Guid.Empty)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.GuidEmptyException, parameterName));
        }
    }

    public static void LessByZero(this IGuardClause guardClause, double input, string parameterName)
    {
        if (input < 0)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.InvalidPrice, parameterName));
        }
    }
}