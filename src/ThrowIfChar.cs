using System.Runtime.CompilerServices;
using ThrowIfArgument.Extensions;

namespace ThrowIfArgument;

public static partial class ThrowIfBuilderExtensions
{
    /// <summary>
    ///     Guards against arguments being ASCII characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not an ASCII character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is an ASCII character.</exception>
    public static char IsAscii
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non ASCII characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is an ASCII character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not an ASCII character.</exception>
    public static char IsNotAscii
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being control characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a control character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a control character.</exception>
    public static char IsControl
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non control characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a control character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a control character.</exception>
    public static char IsNotControl
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being digit characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a digit character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a digit character.</exception>
    public static char IsDigit
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non digit characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a digit character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a digit character.</exception>
    public static char IsNotDigit
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being letter characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a letter character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a letter character.</exception>
    public static char IsLetter
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non letter characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a letter character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a letter character.</exception>
    public static char IsNotLetter
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being lower characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a lower character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a lower character.</exception>
    public static char IsLower
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non lower characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a lower character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a lower character.</exception>
    public static char IsNotLower
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being number characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a number character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a number character.</exception>
    public static char IsNumber
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non number characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a number character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a number character.</exception>
    public static char IsNotNumber
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being punctuation characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a punctuation character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a punctuation character.</exception>
    public static char IsPunctuation
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non punctuation characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a punctuation character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a punctuation character.</exception>
    public static char IsNotPunctuation
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being separator characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a separator character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a separator character.</exception>
    public static char IsSeparator
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non separator characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a separator character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a separator character.</exception>
    public static char IsNotSeparator
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being surrogate characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a surrogate character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a surrogate character.</exception>
    public static char IsSurrogate
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non surrogate characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a surrogate character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a surrogate character.</exception>
    public static char IsNotSurrogate
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being symbol characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a symbol character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a symbol character.</exception>
    public static char IsSymbol
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non symbol characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a symbol character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a symbol character.</exception>
    public static char IsNotSymbol
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being upper characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not an upper character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is an upper character.</exception>
    public static char IsUpper
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non upper characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is an upper character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not an upper character.</exception>
    public static char IsNotUpper
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being high surrogate characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a high surrogate character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a high surrogate character.</exception>
    public static char IsHighSurrogate
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non high surrogate characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a high surrogate character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a high surrogate character.</exception>
    public static char IsNotHighSurrogate
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being low surrogate characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a low surrogate character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a low surrogate character.</exception>
    public static char IsLowSurrogate
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non low surrogate characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a low surrogate character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a low surrogate character.</exception>
    public static char IsNotLowSurrogate
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being white space characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a white space character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a white space character.</exception>
    public static char IsWhiteSpace
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non white space characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a white space character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a white space character.</exception>
    public static char IsNotWhiteSpace
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being letter characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is not a letter character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is a letter character.</exception>
    public static char IsLetterOrDigit
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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

    /// <summary>
    ///     Guards against arguments being non letter and non digit characters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="argument"></param>
    /// <param name="message">Optional custom message.</param>
    /// <param name="argumentName"></param>
    /// <returns><paramref name="argument" /> if it is a letter or digit character.</returns>
    /// <exception cref="ArgumentException">when <paramref name="argument" /> is not a letter nor digit character.</exception>
    public static char IsNotLetterAndNotDigit
    (
        this IThrowIfBuilder builder,
        char argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
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