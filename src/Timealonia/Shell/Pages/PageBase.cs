using Avalonia.Markup.Declarative;
using Timealonia.Shell.Styling;

namespace Timealonia.Shell.Pages;

public abstract class PageBase : ComponentBase
{
    [Inject] public IStyleProvider StyleProvider { get; init; } = null!;

    protected abstract override object Build();
    protected override void OnCreated()
    {
        base.OnCreated();
        StyleProvider.ModeChanged += StateHasChanged;
    }
}