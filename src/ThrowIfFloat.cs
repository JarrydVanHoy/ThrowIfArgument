using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    /// <summary>
    ///     Guards against arguments being equal to <paramref name="comparison" /> within a tolerance of <paramref name="tolerance" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="tolerance"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not equal to <paramref name="comparison" /> within a tolerance of <paramref name="tolerance" />.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is equal to <paramref name="comparison" /> within a tolerance of <paramref name="tolerance" />.</exception>
    public static float IsEqualTo
    (
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        float tolerance,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being not equal to <paramref name="comparison" /> within a tolerance of <paramref name="tolerance" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="tolerance"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is equal to <paramref name="comparison" /> within a tolerance of <paramref name="tolerance" />.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not equal to <paramref name="comparison" /> within a tolerance of <paramref name="tolerance" />.</exception>
    public static float IsNotEqualTo
    (
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        float tolerance,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being equal to zero.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="tolerance"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not equal to zero.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is equal to zero.</exception>
    public static float IsZero
    (
        this IThrowIfBuilder builder,
        float argument,
        float tolerance,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        return ThrowIf.Argument.IsEqualTo(argument, 0f, tolerance, message, argumentName);
    }

    /// <summary>
    ///     Guards against arguments being less than <paramref name="comparison" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not less than <paramref name="comparison" />.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is less than <paramref name="comparison" />.</exception>
    public static float IsLessThan
    (
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being less than or equal to <paramref name="comparison" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not less than nor equal to <paramref name="comparison" />.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is less than or equal to <paramref name="comparison" />.</exception>
    public static float IsLessThanOrEqualTo
    (
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being greater than <paramref name="comparison" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not greater than <paramref name="comparison" />.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is greater than <paramref name="comparison" />.</exception>
    public static float IsGreaterThan
    (
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being greater than or equal to <paramref name="comparison" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not greater than nor equal to <paramref name="comparison" />.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is greater than or equal to <paramref name="comparison" />.</exception>
    public static float IsGreaterThanOrEqualTo
    (
        this IThrowIfBuilder builder,
        float argument,
        float comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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