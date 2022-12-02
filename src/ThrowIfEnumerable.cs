using System.Runtime.CompilerServices;
using System.Text.Json;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static IEnumerable<T> IsEmpty<T>(
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static IEnumerable<T> Any<T>(
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        Func<T, bool> predicate,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static IEnumerable<T> All<T>(
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        Func<T, bool> predicate,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static IEnumerable<T> Contains<T>(
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        T item,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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

    public static IEnumerable<T> DoesNotContain<T>(
        this IThrowIfBuilder builder,
        IEnumerable<T> argument,
        T item,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
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