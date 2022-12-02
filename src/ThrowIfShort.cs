using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static short IsZero(
        this IThrowIfBuilder builder,
        short argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        const short zero = 0;

        return ThrowIf.Argument.IsEqualTo(argument, zero, message, argumentName);
    }

    public static short IsLessThan(
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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

    public static short IsLessThanOrEqualTo(
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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

    public static short IsGreaterThan(
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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

    public static short IsGreaterThanOrEqualTo(
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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