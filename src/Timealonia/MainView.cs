using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;

namespace Timealonia;

public class MainView : ComponentBase
{
    protected override object Build() => 
        new TextBlock().Text("Hello, World!")
            .VerticalAlignment(VerticalAlignment.Center)
            .HorizontalAlignment(HorizontalAlignment.Center);
}