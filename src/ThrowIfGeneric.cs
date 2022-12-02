using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    [return: NotNull]
    public static T IsNull<T>(
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument is not null)
        {
            return argument;
        }

        throw new ArgumentNullException(
            argumentName,
            string.IsNullOrWhiteSpace(message)
                ? "Value cannot be null."
                : message.AddPeriod());
    }

    [return: NotNull]
    public static T IsEqualTo<T>(
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        T comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        ThrowIf.Argument.IsNull(argument, message, argumentName);

        if (!argument.Equals(comparison))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be equal to '{JsonSerializer.Serialize(comparison)}'."
                : message.AddPeriod(),
            argumentName);
    }

    [return: NotNull]
    public static T IsNotEqualTo<T>(
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        T comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        ThrowIf.Argument.IsNull(argument, message, argumentName);

        if (argument.Equals(comparison))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{JsonSerializer.Serialize(argument)}', but must be equal to '{JsonSerializer.Serialize(comparison)}'."
                : message.AddPeriod(),
            argumentName);
    }

    [return: NotNull]
    public static T IsAgainstExpression<T>(
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        Func<T, bool> expression,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        ThrowIf.Argument.IsNull(argument);

        if (expression(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{JsonSerializer.Serialize(argument)}', but did not match your expression."
                : message.AddPeriod(),
            argumentName);
    }

    public static Type IsNotGeneric(
        this IThrowIfBuilder builder,
        Type argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (argument.IsGenericType)
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument.Name}', but must be a generic type."
                : message,
            argumentName);
    }
}