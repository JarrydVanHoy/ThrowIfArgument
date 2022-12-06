# ThrowIfArgument

[![NuGet Status](https://img.shields.io/nuget/v/ThrowIfArgument.svg)](https://www.nuget.org/packages/ThrowIfArgument)
[![NuGet](https://img.shields.io/nuget/dt/ThrowIfArgument.svg)](https://www.nuget.org/packages/ThrowIfArgument)

This is just another guard clause library for validating your arguments, but I enjoy the way using this API reads quite fluently.  If you're like me, then you've been recreating a library of guard clauses from company to company.  I finally got tired and uploaded my own version of a guard clause library.

## NuGet Installation

Install the [ThrowIfArgument NuGet package](https://nuget.org/packages/ThrowIfArgument):

```.NET CLI
dotnet add package ThrowIfArgument
```

## Usage

```C#
public void HelloWorld(FooBar fooBar)
{
    ThrowIf.Argument.IsNull(fooBar);
    
    Console.WriteLine($"The narwhal bacons at {fooBar.BaconsAt}");
}
```

### Extensibility

If you feel the package is missing a feature, you can extend with your own features:

```C#
public static ThrowIfArgumentExtensions
{
    public static string StartsWithThunderclap
    (
        this IThrowIfArgumentBuilder,
        string argument,
        string? message = null,
        [CallerArgumentExpression("argument")] string? argumentName = null
    )
    {
        if (!argument.StartsWith("thunderclap", StringComparison.OrdinalIgnoreCase))
        {  
            return argument;
        }
        
        throw new ArgumentException(
            string.IsNullOrWhiteSpace(message)
                ? $"Cannot start with 'thunderclap'."
                : message,
            argumentName);        
    }
}
```
Ping me if you want any new features added to the library ❤️
