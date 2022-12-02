using System;
using System.ComponentModel.DataAnnotations;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfCharTests
{
    [Theory]
    [AutoData]
    public void IsAscii_ValidChar_DoesNotThrow([Range(128, 255)] byte ascii)
    {
        var argument = (char) ascii;

        var act = () => ThrowIf.Argument.IsAscii(argument);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsAscii_InvalidChar_ThrowsArgumentException([Range(0, 127)] byte ascii)
    {
        var argument = (char) ascii;

        var act = () => ThrowIf.Argument.IsAscii(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be an ASCII character. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNotAscii_ValidChar_DoesNotThrow([Range(0, 127)] byte ascii)
    {
        var argument = (char) ascii;

        var act = () => ThrowIf.Argument.IsNotAscii(argument);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNotAscii_InvalidChar_ThrowsArgumentException([Range(128, 255)] byte ascii)
    {
        var argument = (char) ascii;

        var act = () => ThrowIf.Argument.IsNotAscii(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be an ASCII character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsControl_ValidChar_DoesNotThrow()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsControl(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsControl_InvalidChar_ThrowsArgumentException()
    {
        const char argument = '\t';

        var act = () => ThrowIf.Argument.IsControl(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a control character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotControl_ValidChar_DoesNotThrow()
    {
        const char argument = '\t';

        var act = () => ThrowIf.Argument.IsNotControl(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotControl_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsNotControl(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be a control character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsDigit_ValidChar_DoesNotThrow()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsDigit(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsDigit_InvalidChar_ThrowsArgumentException()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsDigit(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a digit character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotDigit_ValidChar_DoesNotThrow()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsNotDigit(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotDigit_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsNotDigit(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be a digit character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsLetter_ValidChar_DoesNotThrow()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsLetter(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsLetter_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsLetter(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a letter character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotLetter_ValidChar_DoesNotThrow()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsNotLetter(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotLetter_InvalidChar_ThrowsArgumentException()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsNotLetter(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be a letter character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsLower_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsLower(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsLower_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsLower(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a lower character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotLower_ValidChar_DoesNotThrow()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsNotLower(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotLower_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotLower(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be a lower character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNumber_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNumber(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNumber_InvalidChar_ThrowsArgumentException()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsNumber(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a number character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotNumber_ValidChar_DoesNotThrow()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsNotNumber(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotNumber_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotNumber(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be a number character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsPunctuation_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsPunctuation(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsPunctuation_InvalidChar_ThrowsArgumentException()
    {
        const char argument = ',';

        var act = () => ThrowIf.Argument.IsPunctuation(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a punctuation character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotPunctuation_ValidChar_DoesNotThrow()
    {
        const char argument = ',';

        var act = () => ThrowIf.Argument.IsNotPunctuation(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotPunctuation_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotPunctuation(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be a punctuation character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsSeparator_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsSeparator(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsSeparator_InvalidChar_ThrowsArgumentException()
    {
        const char argument = ' ';

        var act = () => ThrowIf.Argument.IsSeparator(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a separator character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotSeparator_ValidChar_DoesNotThrow()
    {
        const char argument = ' ';

        var act = () => ThrowIf.Argument.IsNotSeparator(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotSeparator_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotSeparator(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be a separator character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsSurrogate_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsSurrogate(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsSurrogate_InvalidChar_ThrowsArgumentException()
    {
        const char argument = (char) 0xD800;

        var act = () => ThrowIf.Argument.IsSurrogate(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a surrogate character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotSurrogate_ValidChar_DoesNotThrow()
    {
        const char argument = (char) 0xD800;

        var act = () => ThrowIf.Argument.IsNotSurrogate(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotSurrogate_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotSurrogate(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be a surrogate character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsSymbol_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsSymbol(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsSymbol_InvalidChar_ThrowsArgumentException()
    {
        const char argument = '+';

        var act = () => ThrowIf.Argument.IsSymbol(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a symbol character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotSymbol_ValidChar_DoesNotThrow()
    {
        const char argument = '+';

        var act = () => ThrowIf.Argument.IsNotSymbol(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotSymbol_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotSymbol(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be a symbol character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsUpper_ValidChar_DoesNotThrow()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsUpper(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsUpper_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsUpper(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be an upper character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotUpper_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotUpper(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotUpper_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'a';

        var act = () => ThrowIf.Argument.IsNotUpper(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must be an upper character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsHighSurrogate_ValidChar_DoesNotThrow()
    {
        const char argument = (char) (0xD800 - 1);

        var act = () => ThrowIf.Argument.IsHighSurrogate(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsHighSurrogate_InvalidChar_ThrowsArgumentException()
    {
        const char argument = (char) 0xD800;

        var act = () => ThrowIf.Argument.IsHighSurrogate(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a high surrogate character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotHighSurrogate_ValidChar_DoesNotThrow()
    {
        const char argument = (char) 0xD800;

        var act = () => ThrowIf.Argument.IsNotHighSurrogate(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotHighSurrogate_InvalidChar_ThrowsArgumentException()
    {
        const char argument = (char) (0xD800 - 1);

        var act = () => ThrowIf.Argument.IsNotHighSurrogate(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be a high surrogate character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsLowSurrogate_ValidChar_DoesNotThrow()
    {
        const char argument = (char) (0xDFFF + 1);

        var act = () => ThrowIf.Argument.IsLowSurrogate(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsLowSurrogate_InvalidChar_ThrowsArgumentException()
    {
        const char argument = (char) 0xDFFF;

        var act = () => ThrowIf.Argument.IsLowSurrogate(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a low surrogate character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotLowSurrogate_ValidChar_DoesNotThrow()
    {
        const char argument = (char) 0xDFFF;

        var act = () => ThrowIf.Argument.IsNotLowSurrogate(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotLowSurrogate_InvalidChar_ThrowsArgumentException()
    {
        const char argument = (char) (0xDFFF + 1);

        var act = () => ThrowIf.Argument.IsNotLowSurrogate(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be a low surrogate character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsWhiteSpace_ValidChar_DoesNotThrow()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsWhiteSpace(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsWhiteSpaceInvalidChar_ThrowsArgumentException()
    {
        const char argument = ' ';

        var act = () => ThrowIf.Argument.IsWhiteSpace(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a white space character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotWhiteSpace_ValidChar_DoesNotThrow()
    {
        const char argument = ' ';

        var act = () => ThrowIf.Argument.IsNotWhiteSpace(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotWhiteSpace_InvalidChar_ThrowsArgumentException()
    {
        const char argument = 'A';

        var act = () => ThrowIf.Argument.IsNotWhiteSpace(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be a white space character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsLetterOrDigit_ValidChar_DoesNotThrow()
    {
        const char argument = '\t';

        var act = () => ThrowIf.Argument.IsLetterOrDigit(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsLetterOrDigit_InvalidChar_ThrowsArgumentException()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsLetterOrDigit(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be a letter or digit character. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotLetterAndNotDigit_ValidChar_DoesNotThrow()
    {
        const char argument = '0';

        var act = () => ThrowIf.Argument.IsNotLetterAndNotDigit(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotLetterAndNotDigit_InvalidChar_ThrowsArgumentException()
    {
        const char argument = '\t';

        var act = () => ThrowIf.Argument.IsNotLetterAndNotDigit(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be a letter or digit character. (Parameter '{nameof(argument)}')");
    }
}