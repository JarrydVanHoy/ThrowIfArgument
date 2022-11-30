using System.Runtime.CompilerServices;
using System.Text.Json;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static class ThrowIfGeneric
{
    public static T IsNull<T>(
        this IThrowIfBuilder builder,
        T argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument is not null)
        {
            return argument;
        }

        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentNullException(argumentName);
        }

        throw new ArgumentNullException(argumentName, message.AddPeriod());
    }

    public static T IsEqualTo<T>(
        this IThrowIfBuilder builder,
        T argument,
        T comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!ThrowIf.Argument.IsNull(argument)!.Equals(comparison))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Must not be equal to '{JsonSerializer.Serialize(comparison)}'."
                : message.AddPeriod(),
            argumentName);
    }
}