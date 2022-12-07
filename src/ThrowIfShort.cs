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
    public static short IsZero
    (
        this IThrowIfBuilder builder,
        short argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        const short zero = 0;

        return ThrowIf.Argument.IsEqualTo(argument, zero, message, argumentName);
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
    public static short IsLessThan
    (
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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
    public static short IsLessThanOrEqualTo
    (
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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
    public static short IsGreaterThan
    (
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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
    public static short IsGreaterThanOrEqualTo
    (
        this IThrowIfBuilder builder,
        short argument,
        short comparison,
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