using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Timealonia.Navigation;

namespace Timealonia.Components;

public class Header : ComponentBase
{
    protected override object Build()
        => new Grid().Rows("*, Auto")
            .Children(
                new StackPanel()
                    .Orientation(Orientation.Horizontal)
                    .Spacing(50)
                    .Margin(20, 10)
                    .Children(
                            new TextBlock()
                                .Text("Timealonia")
                                .FontSize(20)
                                .FontWeight(FontWeight.Bold),
                            new NavBar()
                        ),
                new Separator().Row(1)
                );
}