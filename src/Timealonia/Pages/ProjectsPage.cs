using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Timealonia.Projects;

namespace Timealonia.Pages;

public class ProjectsPage : PageBase
{
    protected override Control BuildPage()
    {
        return new TextBlock().Text("Projects Page");
    }
}