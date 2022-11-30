using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfGenericTests
{
    [Theory]
    [AutoData]
    public void IsNull_Primitive_ReturnsExpected(int argument)
    {
        var result = ThrowIf.Argument.IsNull(argument);

        result.Should().Be(argument);
    }

    [Theory]
    [AutoData]
    public void IsNull_ValidObject_ReturnsExpected(string testValue)
    {
        var argument = new {TestValue = testValue};
        var expected = new {TestValue = testValue};

        var result = ThrowIf.Argument.IsNull(argument);

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void IsNull_NullObjectWithDefaultMessage_ThrowsArgumentNullException()
    {
        var argument = (object?) null;

        var act = () => ThrowIf.Argument.IsNull(argument);

        act.Should().Throw<ArgumentNullException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNull_NullObjectWithNullMessage_ThrowsArgumentNullException()
    {
        var argument = (object?) null;

        var act = () => ThrowIf.Argument.IsNull(argument, string.Empty);

        act.Should().Throw<ArgumentNullException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNull_NullObjectWithMessage_ThrowsArgumentNullException(string message)
    {
        var argument = (object?) null;

        var act = () => ThrowIf.Argument.IsNull(argument, message);

        act.Should().Throw<ArgumentNullException>()
            .WithMessage($"{message}. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_Primitive_ReturnsExpected(int argument)
    {
        var result = ThrowIf.Argument.IsEqualTo(argument, argument + 1);

        result.Should().Be(argument);
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_ValidObject_ReturnsExpected(string testValue)
    {
        var argument = new {TestValue = testValue};
        var comparison = new {TestValue = testValue + testValue};
        var expected = new {TestValue = testValue};

        var result = ThrowIf.Argument.IsEqualTo(argument, comparison);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_InvalidPrimitive_ThrowsArgumentException(int argument)
    {
        var act = () => ThrowIf.Argument.IsEqualTo(argument, argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Must not be equal to '{argument}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_InvalidPrimitiveWithMessage_ThrowsArgumentException(int argument, string message)
    {
        var act = () => ThrowIf.Argument.IsEqualTo(argument, argument, message);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"{message}. (Parameter '{nameof(argument)}')");
    }
}