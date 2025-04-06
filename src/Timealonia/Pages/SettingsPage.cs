using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace Timealonia.Pages;

public class SettingsPage : PageBase
{
    protected override object Build()
    {
        return new TextBlock().Text("Settings Page");
    }
}