using System;
using System.ComponentModel.DataAnnotations;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfSByteTests
{
    [Theory]
    [AutoData]
    public void IsZero_ArgumentIsNotZero_DoesNotThrow(sbyte argument)
    {
        var act = () => ThrowIf.Argument.IsZero(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsZero_ArgumentIsZero_ThrowsArgumentException()
    {
        const sbyte argument = 0;

        var act = () => ThrowIf.Argument.IsZero(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument}', but must not be equal to '0'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsLessThan_IsValid_DoesNotThrow([Range(10, 20)] sbyte argument, [Range(0, 10)] sbyte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsLessThan(argument, (sbyte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsLessThan_IsInvalid_ThrowsArgumentException([Range(1, 10)] sbyte argument,
        [Range(1, 10)] sbyte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsLessThan(argument, (sbyte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be less than '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsLessThanOrEqualTo_IsValid_DoesNotThrow([Range(11, 20)] sbyte argument,
        [Range(1, 10)] sbyte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsLessThanOrEqualTo(argument, (sbyte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsLessThanOrEqualTo_IsInvalid_ThrowsArgumentException([Range(1, 10)] sbyte argument,
        [Range(0, 10)] sbyte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsLessThanOrEqualTo(argument, (sbyte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be less than or equal to '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsGreaterThan_IsValid_DoesNotThrow([Range(0, 10)] sbyte argument, [Range(0, 10)] sbyte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsGreaterThan(argument, (sbyte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsGreaterThan_IsInvalid_ThrowsArgumentException([Range(11, 20)] sbyte argument,
        [Range(1, 10)] sbyte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsGreaterThan(argument, (sbyte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be greater than '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsGreaterThanOrEqualTo_IsValid_DoesNotThrow([Range(0, 9)] sbyte argument,
        [Range(1, 10)] sbyte difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsGreaterThanOrEqualTo(argument, (sbyte) comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsGreaterThanOrEqualTo_IsInvalid_ThrowsArgumentException(
        sbyte argument,
        [Range(0, 10)] sbyte difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsGreaterThanOrEqualTo(argument, (sbyte) comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be greater than or equal to '{comparison}'. (Parameter '{nameof(argument)}')");
    }
}