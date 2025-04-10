using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Declarative;
using Avalonia.Styling;
using Timealonia.Styling;

namespace Timealonia.Pages;

public abstract class PageBase : ComponentBase
{
    [Inject] public IStyleProvider StyleProvider { get; init; } = null!;

    protected override StyleGroup BuildStyles() =>
    [
        new Style<TemplatedControl>(s => s.Class("bg1"))
            .Background(StyleProvider.Background1.AsBrush())
    ];

    protected override object Build()
    {
        return new ContentControl()
            .Content(BuildPage);
    }
    
    protected abstract Control BuildPage();
}