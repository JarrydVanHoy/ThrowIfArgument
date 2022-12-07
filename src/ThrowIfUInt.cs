using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    /// <summary>
    ///     Guards against arguments being equal to zero.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not equal to zero.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is equal to zero.</exception>
    public static uint IsZero
    (
        this IThrowIfBuilder builder,
        uint argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        return ThrowIf.Argument.IsEqualTo(argument, 0u, message, argumentName);
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
    public static uint IsLessThan
    (
        this IThrowIfBuilder builder,
        uint argument,
        uint comparison,
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
    public static uint IsLessThanOrEqualTo
    (
        this IThrowIfBuilder builder,
        uint argument,
        uint comparison,
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
    public static uint IsGreaterThan
    (
        this IThrowIfBuilder builder,
        uint argument,
        uint comparison,
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
    public static uint IsGreaterThanOrEqualTo
    (
        this IThrowIfBuilder builder,
        uint argument,
        uint comparison,
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