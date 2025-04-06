using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;

namespace Timealonia.Navigation;

public class NavBar : ComponentBase
{
    [Inject] public INavigator Navigator { get; init; } = null!;
    
    protected override object Build()
    {
        return new StackPanel()
            .Orientation(Orientation.Horizontal)
            .Spacing(20)
            .Children(
                Navigator.GetPages()
                    .Select(p => new NavElement(p)).ToArray<Control>()
            );
    }
}