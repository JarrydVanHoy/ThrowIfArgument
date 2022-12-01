using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static class ThrowIfDouble
{
    public static double Tolerance = 0.00001;
    
    public static double IsEqualTo(
        this IThrowIfBuilder builder,
        double argument,
        double comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (Math.Abs(argument - comparison) > Tolerance)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ?$"Must not be equal to '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }
    
    public static double IsZero(
        this IThrowIfBuilder builder,
        double argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        return ThrowIf.Argument.IsEqualTo(argument, 0d, message, argumentName);
    }

    public static double IsLessThan(
        this IThrowIfBuilder builder,
        double argument,
        double comparison,
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

    public static double IsLessThanOrEqualTo(
        this IThrowIfBuilder builder,
        double argument,
        double comparison,
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
    
    public static double IsGreaterThan(
        this IThrowIfBuilder builder,
        double argument, 
        double comparison, 
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

    public static double IsGreaterThanOrEqualTo(
        this IThrowIfBuilder builder,
        double argument,
        double comparison,
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