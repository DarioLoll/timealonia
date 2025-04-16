using Timealonia.Shell.Pages;

namespace Timealonia.Shell.Navigation;

public interface INavigator
{
    IEnumerable<string> GetPages();
    
    string GetCurrentPageName();

    PageBase GetCurrentPage();
    
    void NavigateTo(string page);
    
    event Action<string, PageBase>? Navigated;
}