using System;
using System.Text.RegularExpressions;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfStringTests
{
    private const string OnlyLetters = "^[a-zA-Z]+$";
    private const string FixtureGuid = "^[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+-[a-zA-Z0-9]+$";

    [Theory]
    [InlineData("   ")]
    [AutoData]
    public void IsNullOrEmpty_IsValid_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsNullOrEmpty(argument);

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void IsNullOrEmpty_IsInvalid_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsNullOrEmpty(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Cannot be null or empty. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNullOrWhiteSpace_IsValid_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsNullOrWhiteSpace(argument);

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void IsNullOrWhiteSpace_IsInvalid_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsNullOrWhiteSpace(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Cannot be null or white space. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsRegexMatch_IsValid_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsRegexMatch(argument, OnlyLetters);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsRegexMatch_IsValidWithOptions_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsRegexMatch(argument, OnlyLetters, new RegexOptions());

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsRegexMatch_IsValidWithTimeout_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsRegexMatch(
            argument,
            OnlyLetters,
            new RegexOptions(),
            TimeSpan.FromSeconds(5));

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsRegexMatch_IsInvalid_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsRegexMatch(argument, FixtureGuid);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but cannot match pattern '{FixtureGuid}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsRegexMatch_IsInvalidWithOptions_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsRegexMatch(argument, FixtureGuid, new RegexOptions());

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but cannot match pattern '{FixtureGuid}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsRegexMatch_IsInvalidWithTimeout_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsRegexMatch(
            argument,
            FixtureGuid,
            new RegexOptions(),
            TimeSpan.FromSeconds(5));

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but cannot match pattern '{FixtureGuid}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNotRegexMatch_IsValid_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsNotRegexMatch(argument, FixtureGuid);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNotRegexMatch_IsValidWithOptions_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsNotRegexMatch(argument, FixtureGuid, new RegexOptions());

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNotRegexMatch_IsValidWithTimeout_DoesNotThrow(string argument)
    {
        var act = () => ThrowIf.Argument.IsNotRegexMatch(
            argument,
            FixtureGuid,
            new RegexOptions(),
            TimeSpan.FromSeconds(5));

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNotRegexMatchIsInvalid_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsNotRegexMatch(argument, OnlyLetters);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must match pattern '{OnlyLetters}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNotRegexMatch_IsInvalidWithOptions_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsNotRegexMatch(argument, OnlyLetters, new RegexOptions());

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must match pattern '{OnlyLetters}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNotRegexMatch_IsInvalidWithTimeout_ThrowsArgumentException(string argument)
    {
        var act = () => ThrowIf.Argument.IsNotRegexMatch(
            argument,
            OnlyLetters,
            new RegexOptions(),
            TimeSpan.FromSeconds(5));

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must match pattern '{OnlyLetters}'. (Parameter '{nameof(argument)}')");
    }
}