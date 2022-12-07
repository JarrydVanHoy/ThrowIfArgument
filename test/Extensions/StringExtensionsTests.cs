using AutoFixture.Xunit2;
using FluentAssertions;
using ThrowIfArgument.Extensions;
using Xunit;

namespace ThrowIfArgument.UnitTests.Extensions;

// ReSharper disable once InconsistentNaming
public class StringExtensionsTests
{
    [Theory]
    [AutoData]
    public void AddPeriod_ValueDoesNotEndInAPeriod_ReturnsWithEndingPeriod
    (
        string value
    )
    {
        var result = value.AddPeriod();

        result.Should().EndWith(".");
    }

    [Theory]
    [AutoData]
    public void AddPeriod_ValueDoesEndInAPeriod_ReturnsAsIs
    (
        string value
    )
    {
        value += ".";

        var result = value.AddPeriod();

        result.Should().EndWith(".")
            .And.NotEndWith("..");
    }
}