using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Timealonia.Shell.Styling;

namespace Timealonia.Shell.Navigation;

public class NavElement(string pageName) : ComponentBase
{
    public string PageName { get; } = pageName;
    
    [Inject] public INavigator Navigator { get; init; } = null!;
    [Inject] public IStyleProvider StyleProvider { get; init; } = null!;

    protected override object Build()
    {
        return new Button()
            .Classes("Tertiary")
            .IsEnabled(() => Navigator.GetCurrentPageName() != PageName)
            .Theme(StyleProvider.BorderlessButton)
            .Content(PageName)
            .OnClick(_ => Navigator.NavigateTo(PageName));
    }

    protected override void OnCreated()
    {
        base.OnCreated();
        Navigator.Navigated += (_, _) => StateHasChanged();
    }
}