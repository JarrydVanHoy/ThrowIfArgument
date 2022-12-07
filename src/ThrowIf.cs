namespace ThrowIfArgument;

/// <summary>
///     Extensible interface to build custom throw if guards.
/// </summary>
public interface IThrowIfBuilder
{
}

/// <summary>
///     Entry point to kick off any throw if guards as extension methods on IThrowIfBuilder.
/// </summary>
public class ThrowIf : IThrowIfBuilder
{
    private ThrowIf()
    {
    }

    /// <summary>
    ///     Entry point to kick off any specific throw if guard.
    /// </summary>
    public static IThrowIfBuilder Argument { get; } = new ThrowIf();
}