using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Timealonia.Utilities;

public static class Themes
{
    public static void Initialize()
    {
        var app = Application.Current;
        if (app == null)
            throw new InvalidOperationException("Application.Current is null");
        if (app.TryGetResource("BorderlessButton", out var resource) && resource is ControlTheme borderlessButton)
            BorderlessButton = borderlessButton;
        else throw new InvalidOperationException("BorderlessButton theme not found");
    }

    public static ControlTheme BorderlessButton { get; private set; } = null!;
}