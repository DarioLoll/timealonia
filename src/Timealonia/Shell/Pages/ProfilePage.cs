using Avalonia.Controls;
using Avalonia.Markup.Declarative;

namespace Timealonia.Shell.Pages;

public class ProfilePage : PageBase
{
    protected override object Build()
    {
        return new TextBlock().Text("Profile Page");
    }
}