using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static decimal IsZero(
        this IThrowIfBuilder builder,
        decimal argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        return ThrowIf.Argument.IsEqualTo(argument, 0, message, argumentName);
    }

    public static decimal IsLessThan(
        this IThrowIfBuilder builder,
        decimal argument,
        decimal comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument >= comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be less than '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }

    public static decimal IsLessThanOrEqualTo(
        this IThrowIfBuilder builder,
        decimal argument,
        decimal comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument > comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be less than or equal to '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }

    public static decimal IsGreaterThan(
        this IThrowIfBuilder builder,
        decimal argument,
        decimal comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument <= comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be greater than '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }

    public static decimal IsGreaterThanOrEqualTo(
        this IThrowIfBuilder builder,
        decimal argument,
        decimal comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument < comparison)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be greater than or equal to '{comparison}'."
                : message.AddPeriod(),
            argumentName);
    }
}