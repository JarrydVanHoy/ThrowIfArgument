using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    public static char IsAscii(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsAscii(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be an ASCII character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotAscii(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsAscii(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be an ASCII character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsControl(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsControl(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a control character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotControl(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsControl(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a control character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsDigit(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsDigit(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a digit character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotDigit(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsDigit(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a digit character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsLetter(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsLetter(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a letter character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotLetter(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsLetter(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a letter character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsLower(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsLower(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a lower character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotLower(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsLower(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a lower character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNumber(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsNumber(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a number character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotNumber(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsNumber(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a number character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsPunctuation(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsPunctuation(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a punctuation character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotPunctuation(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsPunctuation(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a punctuation character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsSeparator(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsSeparator(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a separator character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotSeparator(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsSeparator(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a separator character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsSurrogate(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsSurrogate(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a surrogate character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotSurrogate(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsSurrogate(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a surrogate character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsSymbol(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsSymbol(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a symbol character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotSymbol(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsSymbol(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a symbol character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsUpper(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsUpper(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be an upper character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotUpper(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsUpper(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be an upper character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsHighSurrogate(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsHighSurrogate(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a high surrogate character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotHighSurrogate(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsHighSurrogate(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a high surrogate character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsLowSurrogate(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsLowSurrogate(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a low surrogate character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotLowSurrogate(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsLowSurrogate(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a low surrogate character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsWhiteSpace(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsWhiteSpace(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a white space character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotWhiteSpace(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsWhiteSpace(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a white space character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsLetterOrDigit(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (!char.IsLetterOrDigit(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must not be a letter or digit character."
                : message.AddPeriod(),
            argumentName);
    }

    public static char IsNotLetterAndNotDigit(
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null)
    {
        if (char.IsLetterOrDigit(argument))
        {
            return argument;
        }

        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Value was '{argument}', but must be a letter or digit character."
                : message.AddPeriod(),
            argumentName);
    }
}