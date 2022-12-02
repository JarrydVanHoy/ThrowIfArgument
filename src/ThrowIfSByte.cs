using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static sbyte IsZero(
        this IThrowIfBuilder builder,
        sbyte argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        const sbyte zero = 0;

        return ThrowIf.Argument.IsEqualTo(argument, zero, message, argumentName);
    }

    public static sbyte IsLessThan(
        this IThrowIfBuilder builder,
        sbyte argument,
        sbyte comparison,
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

    public static sbyte IsLessThanOrEqualTo(
        this IThrowIfBuilder builder,
        sbyte argument,
        sbyte comparison,
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

    public static sbyte IsGreaterThan(
        this IThrowIfBuilder builder,
        sbyte argument,
        sbyte comparison,
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

    public static sbyte IsGreaterThanOrEqualTo(
        this IThrowIfBuilder builder,
        sbyte argument,
        sbyte comparison,
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