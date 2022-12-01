using System;
using System.Runtime.CompilerServices;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfStringTests
{
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
}