using System.Runtime.CompilerServices;
using System.Text.Json;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    /// <summary>
    ///     Guards against arguments being null or empty.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not null and not empty.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is empty.</exception>
    public static IEnumerable<T> IsEmpty<T>
    (
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        var argumentList = ThrowIf.Argument.IsNull(argument, message, argumentName).ToList();

        if (argumentList.Any())
        {
            return argumentList;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? "Cannot be empty."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments being null or having any elements matching the <paramref name="predicate" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="predicate"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not null and not having any elements matching the <paramref name="predicate" />.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> contains an element matching the <paramref name="predicate" />.</exception>
    public static IEnumerable<T> Any<T>
    (
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        Func<T, bool> predicate,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        var argumentList = ThrowIf.Argument.IsNull(argument, message, argumentName).ToList();

        if (!argumentList.Any(predicate))
        {
            return argumentList;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? "Cannot have anything matching your predicate."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments being null or having all elements matching the <paramref name="predicate" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="predicate"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not null and not having all elements matching the <paramref name="predicate" />.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> only contains elements matching the <paramref name="predicate" />.</exception>
    public static IEnumerable<T> All<T>
    (
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        Func<T, bool> predicate,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        var argumentList = ThrowIf.Argument.IsNull(argument, message, argumentName).ToList();

        if (!argumentList.All(predicate))
        {
            return argumentList;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? "Cannot have all items match your predicate."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments being null or having any elements equal to <paramref name="item" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="item"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not null and not having any elements equal to <paramref name="item" />.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> contains an element equal to <paramref name="item" />.</exception>
    public static IEnumerable<T> Contains<T>
    (
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        T item,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        var argumentList = ThrowIf.Argument.IsNull(argument, message, argumentName).ToList();

        if (!argumentList.Contains(item))
        {
            return argumentList;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Cannot contain and item equal to '{JsonSerializer.Serialize(item)}'."
                : message.AddPeriod(),
            argumentName);
    }

    /// <summary>
    ///     Guards against arguments being null or not having any elements equal to <paramref name="item" />.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="item"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not null and contains an element equal to <paramref name="item" />.</returns>
    /// <exception cref="ArgumentNullException">when <paramref name="argument" /> is null.</exception>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> contains an element equal to <paramref name="item" />.</exception>
    public static IEnumerable<T> DoesNotContain<T>
    (
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        T item,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        var argumentList = ThrowIf.Argument.IsNull(argument, message, argumentName).ToList();

        if (argumentList.Contains(item))
        {
            return argumentList;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Must contain an item that is equal to '{JsonSerializer.Serialize(item)}'."
                : message.AddPeriod(),
            argumentName);
    }
}