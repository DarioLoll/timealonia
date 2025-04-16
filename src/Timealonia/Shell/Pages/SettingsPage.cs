using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace Timealonia.Shell.Pages;

public class SettingsPage : PageBase
{
    protected override object Build()
    {
        return new TextBlock().Text("Settings Page");
    }
}