using Timealonia.Shell.Pages;

namespace Timealonia.Shell.Navigation;

public class Navigator : INavigator
{
    private readonly IEnumerable<string> _pages;
    
    private readonly Func<string, PageBase> _pageFactory;
    
    private string _currentPageName;
    
    private PageBase _currentPage;

    public Navigator(IEnumerable<string> pages, Func<string, PageBase> pageFactory)
    {
        _pageFactory = pageFactory;
        _pages = pages;
        _currentPageName = _pages.First();
        _currentPage = _pageFactory(_currentPageName);
    }

    public IEnumerable<string> GetPages() => _pages;

    public string GetCurrentPageName() => _currentPageName;

    public PageBase GetCurrentPage() => _currentPage;

    public void NavigateTo(string page)
    {
        if (!_pages.Contains(page))
            throw new ArgumentException($"Page {page} does not exist.");

        _currentPageName = page;
        _currentPage = _pageFactory(_currentPageName);
        Navigated?.Invoke(_currentPageName, _currentPage);
    }

    public event Action<string, PageBase>? Navigated;
}