using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Styling;
using Timealonia.Components;
using Timealonia.Navigation;
using Timealonia.Styling;

namespace Timealonia;

public class MainView : ComponentBase
{
    [Inject] public INavigator Navigator { get; init; } = null!;
    
    [Inject] public IStyleProvider StyleProvider { get; init; } = null!;
    
    protected override object Build() =>
        new Grid()
            .Styles(
                new Style<TextBlock>()
                    .VerticalAlignment(VerticalAlignment.Center)
                )
            .Rows("Auto, *")
            .Children(
                new Header().Row(0),
                new ContentControl().Row(1).Content(Navigator.GetCurrentPage)
                );

    protected override void OnCreated()
    {
        base.OnCreated();
        Navigator.Navigated += (_, _) => StateHasChanged();
        StyleProvider.ModeChanged += StateHasChanged;
    }
}