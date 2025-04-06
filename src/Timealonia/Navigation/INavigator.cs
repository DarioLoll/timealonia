using Avalonia.Markup.Declarative;
using Timealonia.Pages;

namespace Timealonia.Navigation;

public interface INavigator
{
    IEnumerable<string> GetPages();
    
    string GetCurrentPageName();

    PageBase GetCurrentPage();
    
    void NavigateTo(string page);
    
    event Action<string, PageBase>? Navigated;
}