using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static bool IsTrue(
        this IThrowIfBuilder builder,
        bool argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static bool IsFalse(
        this IThrowIfBuilder builder,
        bool argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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