using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static class ThrowIfString
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

}