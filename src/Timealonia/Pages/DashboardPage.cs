using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace Timealonia.Pages;

public class DashboardPage : PageBase
{
    protected override object Build()
    {
        return new TextBlock().Text("Dashboard Page");
    }
}