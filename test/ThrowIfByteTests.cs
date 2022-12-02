using System;
using System.ComponentModel.DataAnnotations;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfByteTests
{
    [Theory]
    [AutoData]
    public void IsZero_ArgumentIsNotZero_DoesNotThrow(byte argument)
    {
        var act = () => ThrowIf.Argument.IsZero(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsZero_ArgumentIsZero_ThrowsArgumentException()
    {
        const byte argument = 0;

        var act = () => ThrowIf.Argument.IsZero(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must not be equal to '0'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsLessThan_IsValid_DoesNotThrow([Range(10, 20)] byte argument, [Range(0, 10)] byte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsLessThan(argument, (byte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsLessThan_IsInvalid_ThrowsArgumentException([Range(1, 10)] byte argument,
        [Range(1, 10)] byte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsLessThan(argument, (byte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be less than '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsLessThanOrEqualTo_IsValid_DoesNotThrow([Range(11, 20)] byte argument, [Range(1, 10)] byte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsLessThanOrEqualTo(argument, (byte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsLessThanOrEqualTo_IsInvalid_ThrowsArgumentException([Range(1, 10)] byte argument,
        [Range(0, 10)] byte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsLessThanOrEqualTo(argument, (byte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be less than or equal to '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsGreaterThan_IsValid_DoesNotThrow([Range(0, 10)] byte argument, [Range(0, 10)] byte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsGreaterThan(argument, (byte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsGreaterThan_IsInvalid_ThrowsArgumentException([Range(11, 20)] byte argument,
        [Range(1, 10)] byte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsGreaterThan(argument, (byte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be greater than '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsGreaterThanOrEqualTo_IsValid_DoesNotThrow([Range(0, 9)] byte argument, [Range(1, 10)] byte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsGreaterThanOrEqualTo(argument, (byte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsGreaterThanOrEqualTo_IsInvalid_ThrowsArgumentException(
        byte argument,
        [Range(0, 10)] byte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsGreaterThanOrEqualTo(argument, (byte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be greater than or equal to '{comparison}'. (Parameter '{nameof(argument)}')");
    }
}