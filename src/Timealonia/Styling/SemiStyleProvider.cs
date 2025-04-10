using Avalonia;
using Avalonia.Media;
using Avalonia.Styling;
using Timealonia.Utilities;

namespace Timealonia.Styling;

public class SemiStyleProvider : IStyleProvider
{
    private readonly Application _app = Application.Current 
                                        ?? throw new InvalidOperationException("Application.Current is null");

    public bool IsInDarkMode => _app.ActualThemeVariant == ThemeVariant.Dark;
    public event Action? ModeChanged;
    public void ToggleMode()
    {
        _app.RequestedThemeVariant = IsInDarkMode ? ThemeVariant.Light : ThemeVariant.Dark;
        ModeChanged?.Invoke();
    }

    public Color Background0 => _app.GetResource<Color>("SemiBackground0Color");
    public Color Background1 => _app.GetResource<Color>("SemiBackground1Color");
    public Color Background2 => _app.GetResource<Color>("SemiBackground2Color");
    public Color Background3 => _app.GetResource<Color>("SemiBackground3Color");
    public Color Background4 => _app.GetResource<Color>("SemiBackground4Color");
    public ControlTheme BorderlessButton => _app.GetResource<ControlTheme>("BorderlessButton");
}