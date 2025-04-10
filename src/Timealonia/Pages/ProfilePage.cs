using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace Timealonia.Pages;

public class ProfilePage : PageBase
{
    protected override Control BuildPage()
    {
        return new TextBlock().Text("Profile Page");
    }
}