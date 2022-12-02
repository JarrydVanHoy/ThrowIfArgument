using System;
using System.Collections.Generic;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfEnumerableTests
{
    [Theory]
    [AutoData]
    public void IsEmpty_ArgumentIsValid_DoesNotThrow(List<int> argument)
    {
        var act = () => ThrowIf.Argument.IsEmpty(argument);

        act.Should().NotThrow();
    }

    [Fact]
    public void IsEmpty_ArgumentIsInvalid_ThrowsArgumentException()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var argument = new List<int>();

        var act = () => ThrowIf.Argument.IsEmpty(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Cannot be empty. (Parameter '{nameof(argument)}')");
    }
    
    [Theory]
    [AutoData]
    public void Any_ArgumentIsValid_DoesNotThrow(List<int> argument)
    {
        var act = () => ThrowIf.Argument.Any(argument, _ => _ is int.MinValue);

        act.Should().NotThrow();
    }
    
    [Theory]
    [AutoData]
    public void Any_ArgumentIsInvalid_ThrowsArgumentException(List<int> argument)
    {
        var act = () => ThrowIf.Argument.Any(argument, _ => _ == argument[0]);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Cannot have anything matching your predicate. (Parameter '{nameof(argument)}')");
    }
    
    [Theory]
    [AutoData]
    public void All_ArgumentIsValid_DoesNotThrow(List<int> argument)
    {
        var act = () => ThrowIf.Argument.All(argument, _ => _ == argument[0]);

        act.Should().NotThrow();
    }
    
    [Theory]
    [AutoData]
    public void All_ArgumentIsInvalid_ThrowsArgumentException(List<int> argument)
    {
        var act = () => ThrowIf.Argument.All(argument, _ => _ is not int.MaxValue);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Cannot have all items match your predicate. (Parameter '{nameof(argument)}')");
    }
    
    [Theory]
    [AutoData]
    public void Contains_ArgumentIsValid_DoesNotThrow(List<int> argument)
    {
        var act = () => ThrowIf.Argument.Contains(argument, int.MaxValue);

        act.Should().NotThrow();
    }
    
    [Theory]
    [AutoData]
    public void Contains_ArgumentIsInvalid_ThrowsArgumentException(List<int> argument)
    {
        var act = () => ThrowIf.Argument.Contains(argument, argument[1]);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Cannot contain and item equal to '{argument[1]}'. (Parameter '{nameof(argument)}')");
    }
    
    [Theory]
    [AutoData]
    public void DoesNotContain_ArgumentIsValid_DoesNotThrow(List<int> argument)
    {
        var act = () => ThrowIf.Argument.DoesNotContain(argument, argument[1]);

        act.Should().NotThrow();
    }
    
    [Theory]
    [AutoData]
    public void DoesNotContain_ArgumentIsInvalid_ThrowsArgumentException(List<int> argument)
    {
        var act = () => ThrowIf.Argument.DoesNotContain(argument, int.MaxValue);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Must contain an item that is equal to '{int.MaxValue}'. (Parameter '{nameof(argument)}')");
    }
}