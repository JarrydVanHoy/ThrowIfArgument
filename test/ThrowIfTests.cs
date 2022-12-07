using System;
using System.Runtime.CompilerServices;
using FluentAssertions;
using Xunit;

namespace ThrowIfArgument.UnitTests;

public class ThrowIfTests
{
    [Fact]
    public void Is100_TestingBuilderExtensibility_Throws()
    {
        const int argument = 100;

        var act = () => ThrowIf.Argument.Is100(argument);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Cannot be 100 (Parameter '{nameof(argument)}')");
    }
}

// ReSharper disable once InconsistentNaming
public static class TestExtensions
{
    public static IThrowIfBuilder Is100
    (
        this IThrowIfBuilder throwIfBuilder,
        int argument,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (argument is not 100)
        {
            return throwIfBuilder;
        }

        throw new ArgumentException("Cannot be 100", argumentName);
    }
}