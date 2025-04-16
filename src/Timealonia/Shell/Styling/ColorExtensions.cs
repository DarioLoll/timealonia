using Avalonia.Media;

namespace Timealonia.Shell.Styling;

public static class ColorExtensions
{
    public static IBrush AsBrush(this Color color) => new SolidColorBrush(color);
}