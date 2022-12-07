using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    /// <summary>
    ///     Guards against arguments being null or empty strings.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not null and not empty string.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> a null or empty string.</exception>
    public static string IsNullOrEmpty
    (
        this IThrowIfBuilder builder,
        string argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (!string.IsNullOrEmpty(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? "Cannot be null or empty."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments being null or white space strings.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not null and not white space string.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> a null or white space string.</exception>
    public static string IsNullOrWhiteSpace
    (
        this IThrowIfBuilder builder,
        string argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (!string.IsNullOrWhiteSpace(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? "Cannot be null or white space."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments matching a regex pattern.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="pattern"></param>
    /// <param name="options">Optional regex options.</param>
    /// <param name="matchTimeout">Optional regex timeout.</param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not matching the regex pattern.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> matching the regex pattern.</exception>
    public static string IsRegexMatch
    (
        this IThrowIfBuilder builder,
        string argument,
        string pattern,
        RegexOptions? options = null,
        TimeSpan? matchTimeout = null,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (options is null)
        {
            if (!Regex.IsMatch(argument, pattern))
            {
                return argument;
            }
        }
        else if (matchTimeout is null)
        {
            if (!Regex.IsMatch(argument, pattern, options.Value))
            {
                return argument;
            }
        }
        else if (!Regex.IsMatch(argument, pattern, options.Value, matchTimeout.Value))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but cannot match pattern '{pattern}'."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments not matching a regex pattern.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="pattern"></param>
    /// <param name="options">Optional regex options.</param>
    /// <param name="matchTimeout">Optional regex timeout.</param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is matching the regex pattern.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not matching the regex pattern.</exception>
    public static string IsNotRegexMatch
    (
        this IThrowIfBuilder builder,
        string argument,
        string pattern,
        RegexOptions? options = null,
        TimeSpan? matchTimeout = null,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (options is null)
        {
            if (Regex.IsMatch(argument, pattern))
            {
                return argument;
            }
        }
        else if (matchTimeout is null)
        {
            if (Regex.IsMatch(argument, pattern, options.Value))
            {
                return argument;
            }
        }
        else if (Regex.IsMatch(argument, pattern, options.Value, matchTimeout.Value))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must match pattern '{pattern}'."
                : message.AddPeriod(),
            argumentName);
    }
}