using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Avalonia.Styling;
using Timealonia.Extensions;
using Timealonia.Pages;

namespace Timealonia.Navigation;

public class NavElement(string pageName) : ComponentBase
{
    public string PageName { get; } = pageName;
    
    [Inject] public INavigator Navigator { get; init; } = null!;

    protected override object Build()
    {
        return new Button()
            .Classes("Tertiary")
            .IsEnabled(() => Navigator.GetCurrentPageName() != PageName)
            .Theme(Themes.BorderlessButton)
            .Content(PageName)
            .OnClick(_ => Navigator.NavigateTo(PageName));
    }

    protected override void OnCreated()
    {
        base.OnCreated();
        Navigator.Navigated += (_, _) => StateHasChanged();
    }
}