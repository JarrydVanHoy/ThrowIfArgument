namespace ThrowIfArgument;

public interface IThrowIfBuilder
{
}

public class ThrowIf : IThrowIfBuilder
{
    private ThrowIf()
    {
    }

    public static IThrowIfBuilder Argument { get; } = new ThrowIf();
}