using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

/// <summary>
///     A collection of common throw if guards
/// </summary>
public static partial class ThrowIfBuilderExtensions
{
    /// <summary>
    ///     Guards against null arguments.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns><paramref name="argument" /> if it is not null.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> is null.</exception>
    [return: NotNull]
    public static T IsNull<T>
    (
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against equal arguments.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns><paramref name="argument" /> if it is not null and is not equal to <paramref name="comparison" />.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> or <paramref name="comparison" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is equal to <paramref name="comparison" />.</exception>
    [return: NotNull]
    public static T IsEqualTo<T>
    (
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        [NotNull] T comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        ThrowIf.Argument.IsNull(argument, message, argumentName);
        ThrowIf.Argument.IsNull(comparison);

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

    /// <summary>
    ///     Guards against arguments being unequal.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="comparison"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns><paramref name="argument" /> if it is not null and is equal to <paramref name="comparison" />.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> or <paramref name="comparison" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not equal to <paramref name="comparison" />.</exception>
    [return: NotNull]
    public static T IsNotEqualTo<T>
    (
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        [NotNull] T comparison,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        ThrowIf.Argument.IsNull(argument, message, argumentName);
        ThrowIf.Argument.IsNull(comparison);

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

    /// <summary>
    ///     Guards against arguments not matching an expression.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="expression"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns><paramref name="argument" /> if it is not null and matches <paramref name="expression" />.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> does not match <paramref name="expression" />.</exception>
    [return: NotNull]
    public static T IsAgainstExpression<T>
    (
        this IThrowIfBuilder builder,
        [NotNull] T argument,
        Func<T, bool> expression,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments not being generic types.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is generic type.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a generic type.</exception>
    public static Type IsNotGeneric
    (
        this IThrowIfBuilder builder,
        Type argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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