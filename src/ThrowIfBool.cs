using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    /// <summary>
    ///     Guards against arguments being true.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is false.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is true.</exception>
    public static bool IsTrue
    (
        this IThrowIfBuilder builder,
        bool argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (!argument)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? "Value cannot be true."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments being false.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is true.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is false.</exception>
    public static bool IsFalse
    (
        this IThrowIfBuilder builder,
        bool argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (argument)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? "Value cannot be false."
                : message.AddPeriod(),
            argumentName);
    }
}