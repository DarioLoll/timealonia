using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using Timealonia.Navigation;
using Timealonia.Styling;
using Timealonia.Utilities;

namespace Timealonia.Components;

public class Header : ComponentBase
{
    [Inject] public IStyleProvider StyleProvider { get; init; } = null!;
    
    protected override object Build()
        => new Grid().Rows("*, Auto")
            .Background(() => StyleProvider.Background1.AsBrush())
            .Children(
                new Grid().Cols("*, Auto")
                    .Margin(20, 10)
                    .Children(
                        new StackPanel()
                            .Orientation(Orientation.Horizontal)
                            .Spacing(50)
                            .Children(
                                new TextBlock()
                                    .Text("Timealonia")
                                    .FontSize(20)
                                    .FontWeight(FontWeight.Bold),
                                new NavBar()
                            ),
                        new Button()
                            .OnClick(_ => StyleProvider.ToggleMode())
                            .Theme(StyleProvider.BorderlessButton)
                            .Classes("Tertiary")
                            .Icon(() => StyleProvider.IsInDarkMode ? "mdi-white-balance-sunny" : "mdi-weather-night")
                            .Col(1)
                        ),
                new Separator().Row(1)
                );

    protected override void OnCreated()
    {
        base.OnCreated();
        StyleProvider.ModeChanged += StateHasChanged;
    }
}