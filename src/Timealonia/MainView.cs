using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.MaterialDesign;

namespace Timealonia;

public class MainView : ComponentBase
{

    protected override object Build() => 
        new TabControl()
            .TabStripPlacement(Dock.Left)
            .Items(
                new TabItem()
                    .Header(new StackPanel()
                        .Orientation(Orientation.Horizontal)
                        .Children(
                            new TextBlock().Text("Tasks"),
                            new Ico("mdi-check")
                        ))
                    .Content(new TextBlock().Text("dfdf")),
                new TabItem()
                    .Header("Projects")
                    .Content(new TextBlock().Text("Tasks View")),
                new TabItem()
                    .Header("Settings")
                    .Content(new TextBlock().Text("Records View"))
            );
}