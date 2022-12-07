namespace ThrowIfArgument.Extensions;

// ReSharper disable once InconsistentNaming
internal static class StringExtensions
{
    internal static string AddPeriod
    (
        this string value
    )
    {
        return value[^1] is '.'
            ? value
            : $"{value}.";
    }
}