using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Declarative;
using Avalonia.Styling;
using Timealonia.Extensions;

namespace Timealonia.Navigation;

public class NavElement(string pageName) : ComponentBase
{
    public string PageName { get; } = pageName;
    
    [Inject] public INavigator Navigator { get; init; } = null!;

    protected override object Build()
    {
        return new Button()
            .Classes("Tertiary")
            .Theme(Themes.BorderlessButton)
            .Content(PageName)
            .OnClick(_ => Navigator.NavigateTo(PageName));
    }
}