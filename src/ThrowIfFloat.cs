using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static float IsEqualTo(
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        float tolerance,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (Math.Abs(argument - comparison) > tolerance)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be equal to '{comparison}' within tolerance of '{tolerance}'."
                : message.AddPeriod(),
            argumentName);
    }

    public static float IsNotEqualTo(
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        float tolerance,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (Math.Abs(argument - comparison) <= tolerance)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be equal to '{comparison}' within tolerance of '{tolerance}'."
                : message.AddPeriod(),
            argumentName);
    }

    public static float IsZero(
        this IThrowIfBuilder builder,
        float argument,
        float tolerance,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        return ThrowIf.Argument.IsEqualTo(argument, 0f, tolerance, message, argumentName);
    }

    public static float IsLessThan(
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
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

    public static float IsLessThanOrEqualTo(
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
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

    public static float IsGreaterThan(
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
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

    public static float IsGreaterThanOrEqualTo(
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
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