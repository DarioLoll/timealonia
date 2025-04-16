using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Timealonia.Shell.Styling;
using Timealonia.Shell.Utilities;

namespace Timealonia.Shell.Pages;

public class ProjectsPage : PageBase
{
    protected override object Build()
    {
        return new Grid()
            .Cols("0.3*, Auto, *")
            .Children(
                new Grid()
                    .Col(0)
                    .Rows("Auto, Auto, *")
                    .Background(() => StyleProvider.Background1.AsBrush())
                    .Children(
                        new Button()
                            .IconAndText(() => "mdi-plus", () => "Add Project")
                            .Theme(StyleProvider.SolidButton)
                            .Margin(20)
                            .HorizontalAlignment(HorizontalAlignment.Stretch),
                        new Separator()
                            .Row(1),
                        new StackPanel()
                            .Row(2)
                            .Children(
                                new TextBlock().Text("Projects")
                            )
                        ),
                new GridSplitter()
                    .Width(3)
                    .Col(1),
                new Grid()
                    .Col(2)
                    .Children(
                        new TextBlock().Text("Selected Project")
                        )
            );
    }
}