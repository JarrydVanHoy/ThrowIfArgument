using System;
using System.ComponentModel.DataAnnotations;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfFloatTests
{
    private readonly Random _random = new();

    [Theory]
    [AutoData]
    public void IsEqualTo_DifferenceIsOutsideTolerance_DoesNotThrow(float argument)
    {
        var tolerance = (float) _random.NextDouble();
        var comparison = (float) (argument + tolerance + new Random().NextDouble());

        var act = () => ThrowIf.Argument.IsEqualTo(argument, comparison, tolerance);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_DifferenceIsWithinTolerance_ThrowsArgumentException(float argument)
    {
        var tolerance = (float) _random.NextDouble();
        var comparison = (float) (argument - tolerance * _random.NextDouble());

        var act = () => ThrowIf.Argument.IsEqualTo(argument, comparison, tolerance);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be equal to '{comparison}' within tolerance of '{tolerance}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNotEqualTo_DifferenceIsOutsideTolerance_DoesNotThrow(float argument)
    {
        var tolerance = (float) _random.NextDouble();
        var comparison = (float) (argument + tolerance * new Random().NextDouble());

        var act = () => ThrowIf.Argument.IsNotEqualTo(argument, comparison, tolerance);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNotEqualTo_DifferenceIsWithinTolerance_ThrowsArgumentException(float argument)
    {
        var tolerance = (float) _random.NextDouble();
        var comparison = (float) (argument + tolerance * 1.1d);

        var act = () => ThrowIf.Argument.IsNotEqualTo(argument, comparison, tolerance);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be equal to '{comparison}' within tolerance of '{tolerance}'. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsZero_ArgumentIsNotZero_DoesNotThrow()
    {
        var argument = (float) _random.NextDouble();
        var tolerance = argument * 0.999_999f;

        var act = () => ThrowIf.Argument.IsZero(argument, tolerance);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsZero_ArgumentIsZero_ThrowsArgumentException()
    {
        var argument = (float) _random.NextDouble();
        var tolerance = argument * 1.000_001f;

        var act = () => ThrowIf.Argument.IsZero(argument, tolerance);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be equal to '0' within tolerance of '{tolerance}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsLessThan_IsValid_DoesNotThrow(float argument, [Range(0, 10)] int difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsLessThan(argument, comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsLessThan_IsInvalid_ThrowsArgumentException(float argument, [Range(1, 10)] int difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsLessThan(argument, comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be less than '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsLessThanOrEqualTo_IsValid_DoesNotThrow(float argument, [Range(1, 10)] int difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsLessThanOrEqualTo(argument, comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsLessThanOrEqualTo_IsInvalid_ThrowsArgumentException(float argument, [Range(0, 10)] int difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsLessThanOrEqualTo(argument, comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be less than or equal to '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsGreaterThan_IsValid_DoesNotThrow(float argument, [Range(0, 10)] int difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsGreaterThan(argument, comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsGreaterThan_IsInvalid_ThrowsArgumentException(float argument, [Range(1, 10)] int difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsGreaterThan(argument, comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be greater than '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsGreaterThanOrEqualTo_IsValid_DoesNotThrow(float argument, [Range(1, 10)] int difference)
    {
        var comparison = argument + difference;

        var act = () => ThrowIf.Argument.IsGreaterThanOrEqualTo(argument, comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsGreaterThanOrEqualTo_IsInvalid_ThrowsArgumentException(float argument, [Range(0, 10)] int difference)
    {
        var comparison = argument - difference;

        var act = () => ThrowIf.Argument.IsGreaterThanOrEqualTo(argument, comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be greater than or equal to '{comparison}'. (Parameter '{nameof(argument)}')");
    }
}