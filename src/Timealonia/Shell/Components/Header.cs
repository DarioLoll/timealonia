using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Timealonia.Shell.Navigation;
using Timealonia.Shell.Styling;
using Timealonia.Shell.Utilities;

namespace Timealonia.Shell.Components;

public class Header : ComponentBase
{
    [Inject] public IStyleProvider StyleProvider { get; init; } = null!;
    
    protected override object Build()
        => new Grid().Rows("*, Auto")
            .Background(() => StyleProvider.Background2.AsBrush())
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