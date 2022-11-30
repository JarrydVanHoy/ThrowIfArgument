using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static class ThrowIfInt
{
    public static int IsZero(
        this IThrowIfBuilder builder,
        int argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        return ThrowIf.Argument.IsEqualTo(argument, 0, message, argumentName);
    }

    public static int IsLessThan(
        this IThrowIfBuilder builder,
        int argument,
        int comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument >= comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Must not be less than '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }

    public static int IsLessThanOrEqualTo(
        this IThrowIfBuilder builder,
        int argument,
        int comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument > comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Must not be less than or equal to '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }
    
    public static int IsGreaterThan(
        this IThrowIfBuilder builder,
        int argument, 
        int comparison, 
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument <= comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Must not be greater than '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }

    public static int IsGreaterThanOrEqualTo(
        this IThrowIfBuilder builder,
        int argument,
        int comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument < comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Must not be greater than or equal to '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }
}