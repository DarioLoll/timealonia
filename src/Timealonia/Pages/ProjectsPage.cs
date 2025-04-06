using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace Timealonia.Pages;

public class ProjectsPage : PageBase
{
    protected override object Build()
    {
        return new TextBlock().Text("Projects Page");
    }
}