namespace ThrowIfArgument.Extensions;

internal static class StringExtensions
{
    internal static string AddPeriod(this string value)
    {
        return value[^1] is '.'
            ? value
            : $"{value}.";
    }
}