using Avalonia;
using Avalonia.Controls;

namespace Timealonia.Utilities;

public static class ApplicationExtensions
{
    public static T GetResource<T>(this Application app, string key)
    {
        if (app.TryGetResource(key, app.ActualThemeVariant, out var resource) && resource is T typedResource)
            return typedResource;
        
        throw new InvalidOperationException($"{key} not found or not of type {typeof(T)}");
    }
    
    public static Option<T> TryGetResource<T>(this Application app, string key) where T : class
    {
        if (app.TryGetResource(key, app.ActualThemeVariant, out var resource) && resource is T typedResource)
            return Option<T>.Some(typedResource);
        
        return Option<T>.None();
    }
}