using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfGenericTests
{
    [Theory]
    [AutoData]
    public void IsNull_ValidPrimitive_DoesNotThrow(int argument)
    {
        var act = () => ThrowIf.Argument.IsNull(argument);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNull_ValidObject_DoesNotThrow(string testValue)
    {
        var argument = new {TestValue = testValue};

        var act = () => ThrowIf.Argument.IsNull(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNull_InvalidObject_ThrowsArgumentNullException()
    {
        var argument = (object?) null;

        var act = () => ThrowIf.Argument.IsNull(argument);

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
    public void IsEqualTo_Primitive_DoesNotThrow(int argument)
    {
        var act = () => ThrowIf.Argument.IsEqualTo(argument, argument + 1);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_ValidObject_DoesNotThrow(string testValue)
    {
        var argument = new {TestValue = testValue};
        var comparison = new {TestValue = testValue + testValue};

        var act = () => ThrowIf.Argument.IsEqualTo(argument, comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_InvalidPrimitive_ThrowsArgumentException(int argument)
    {
        var act = () => ThrowIf.Argument.IsEqualTo(argument, argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be equal to '{argument}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsEqualTo_InvalidObject_ThrowsArgumentException(string testValue)
    {
        var argument = new {TestValue = testValue};
        var comparison = new {TestValue = testValue};

        var act = () => ThrowIf.Argument.IsEqualTo(argument, comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must not be equal to '{JsonSerializer.Serialize(argument)}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNotEqualTo_Primitive_DoesNotThrow(int argument)
    {
        var act = () => ThrowIf.Argument.IsNotEqualTo(argument, argument);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNotEqualTo_ValidObject_DoesNotThrow(string testValue)
    {
        var argument = new {TestValue = testValue};
        var comparison = new {TestValue = testValue};

        var act = () => ThrowIf.Argument.IsNotEqualTo(argument, comparison);

        act.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsNotEqualTo_InvalidPrimitive_ThrowsArgumentException(int argument, int comparison)
    {
        var act = () => ThrowIf.Argument.IsNotEqualTo(argument, comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but must be equal to '{comparison}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsNotEqualTo_InvalidObject_ThrowsArgumentException(string testValue)
    {
        var argument = new {TestValue = testValue};
        var comparison = new {TestValue = testValue + testValue};

        var act = () => ThrowIf.Argument.IsNotEqualTo(argument, comparison);

        act.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{JsonSerializer.Serialize(argument)}', but must be equal to '{JsonSerializer.Serialize(comparison)}'. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsAgainstExpression_IntMatches_DoesNotThrow([Range(0, 100)] int argument)
    {
        var action = () => ThrowIf.Argument.IsAgainstExpression(argument, i => i is >= 0 and <= 100);

        action.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsAgainstExpression_IntDoesNotMatch_ThrowsArgumentException([Range(0, 100)] int argument)
    {
        var action = () => ThrowIf.Argument.IsAgainstExpression(argument, i => i is < 0 or > 100);

        action.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{argument}', but did not match your expression. (Parameter '{nameof(argument)}')");
    }

    [Theory]
    [AutoData]
    public void IsAgainstExpression_TestClassMatches_DoesNotThrow(TestClass argument)
    {
        var action = () => ThrowIf.Argument.IsAgainstExpression(argument, i => i.TestField is "Willy Wonka");

        action.Should().NotThrow();
    }

    [Theory]
    [AutoData]
    public void IsAgainstExpression_TestClassDoesNotMatch_ThrowsArgumentException(TestClass argument)
    {
        var action = () => ThrowIf.Argument.IsAgainstExpression(argument, i => i.TestField is not "Willy Wonka");

        action.Should().Throw<ArgumentException>()
            .WithMessage(
                $"Value was '{JsonSerializer.Serialize(argument)}', but did not match your expression. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsNotGeneric_ValidArgument_DoesNotThrow()
    {
        var argument = typeof(TestGenericClass<>);

        var act = () => ThrowIf.Argument.IsNotGeneric(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsNotGeneric_InvalidArgument_ThrowsArgumentException()
    {
        var argument = typeof(TestClass);

        var act = () => ThrowIf.Argument.IsNotGeneric(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value was '{argument.Name}', but must be a generic type. (Parameter '{nameof(argument)}')");
    }

    public class TestClass
    {
        public string TestField => "Willy Wonka";
    }

    public class TestGenericClass<T>
    {
        public int TestField { get; set; }
    }
}