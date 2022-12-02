using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static string IsNullOrEmpty(
        this IThrowIfBuilder builder,
        string argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static string IsNullOrWhiteSpace(
        this IThrowIfBuilder builder,
        string argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static string IsRegexMatch(
        this IThrowIfBuilder builder,
        string argument,
        string pattern,
        RegexOptions? options = null,
        TimeSpan? matchTimeout = null,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static string IsNotRegexMatch(
        this IThrowIfBuilder builder,
        string argument,
        string pattern,
        RegexOptions? options = null,
        TimeSpan? matchTimeout = null,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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