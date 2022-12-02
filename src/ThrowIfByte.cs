using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static byte IsZero(
        this IThrowIfBuilder builder,
        byte argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        const byte zero = 0;

        return ThrowIf.Argument.IsEqualTo(argument, zero, message, argumentName);
    }

    public static byte IsLessThan(
        this IThrowIfBuilder builder,
        byte argument,
        byte comparison,
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

    public static byte IsLessThanOrEqualTo(
        this IThrowIfBuilder builder,
        byte argument,
        byte comparison,
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

    public static byte IsGreaterThan(
        this IThrowIfBuilder builder,
        byte argument,
        byte comparison,
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

    public static byte IsGreaterThanOrEqualTo(
        this IThrowIfBuilder builder,
        byte argument,
        byte comparison,
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