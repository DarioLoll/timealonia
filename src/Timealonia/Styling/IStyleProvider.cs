using Avalonia.Media;
using Avalonia.Styling;

namespace Timealonia.Styling;

public interface IStyleProvider
{
    bool IsInDarkMode { get; }
    event Action? ModeChanged;
    void ToggleMode();
    Color Background0 { get; }
    Color Background1 { get; }
    Color Background2 { get; }
    Color Background3 { get; }
    Color Background4 { get; }
    ControlTheme BorderlessButton { get; }
}