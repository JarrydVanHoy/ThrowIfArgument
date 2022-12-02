using System;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfBoolTests
{
    [Fact]
    public void IsTrue_ArgumentIsValid_DoesNotThrow()
    {
        const bool argument = false;

        var act = () => ThrowIf.Argument.IsTrue(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsTrue_ArgumentIsInvalid_ThrowsArgumentException()
    {
        const bool argument = true;

        var act = () => ThrowIf.Argument.IsTrue(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value cannot be true. (Parameter '{nameof(argument)}')");
    }

    [Fact]
    public void IsFalse_ArgumentIsValid_DoesNotThrow()
    {
        const bool argument = true;

        var act = () => ThrowIf.Argument.IsFalse(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsFalse_ArgumentIsInvalid_ThrowsArgumentException()
    {
        const bool argument = false;

        var act = () => ThrowIf.Argument.IsFalse(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Value cannot be false. (Parameter '{nameof(argument)}')");
    }
}