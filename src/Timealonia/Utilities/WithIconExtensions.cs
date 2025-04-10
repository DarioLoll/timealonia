using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Projektanker.Icons.Avalonia;
using Timealonia.Components;

namespace Timealonia.Utilities;

public enum IconPlacement
{
    Left,
    Right,
    Top,
    Bottom
}

public static class WithIconExtensions
{
    public static TControl Icon<TControl>(this TControl control, Func<string> iconName) 
        where TControl : ContentControl 
        => control.Content(() => new Ico(iconName()));
    
    public static TControl IconAndText<TControl>(this TControl control, Func<string> iconName, Func<string> text, 
        IconPlacement placement = IconPlacement.Left) 
        where TControl : ContentControl 
        => control.IconAndText(iconName, new TextBlock().Text(text), placement);
    
    public static TControl IconAndText<TControl>(this TControl control, Func<string> iconName, TextBlock text, 
        IconPlacement placement = IconPlacement.Left) 
        where TControl : ContentControl 
        => control.Content(() => text.Group(new Ico(iconName()), placement));

    public static StackPanel Group<TControl, TControl2>(this TControl control, TControl2 control2,
        IconPlacement control2Placement = IconPlacement.Left)
        where TControl : Control
        where TControl2 : Control
    {
        var stackPanel = control2Placement switch
        {
            IconPlacement.Left or IconPlacement.Top => control.PlaceBefore(control2),
            IconPlacement.Right or IconPlacement.Bottom => control.PlaceAfter(control2),
            _ => throw new ArgumentOutOfRangeException(nameof(control2Placement), control2Placement, null)
        };
        stackPanel.Orientation = control2Placement is IconPlacement.Left or IconPlacement.Right
            ? Orientation.Horizontal
            : Orientation.Vertical;
        stackPanel.Spacing(5);
        return stackPanel;
    }

    private static StackPanel PlaceBefore<TControl, TControl2>(this TControl control, TControl2 control2) 
        where TControl : Control 
        where TControl2 : Control
    {
        var stackPanel = new StackPanel
        {
            Children =
            {
                control2,
                control
            }
        };
        
        return stackPanel;
    }
    
    private static StackPanel PlaceAfter<TControl, TControl2>(this TControl control, TControl2 control2) 
        where TControl : Control 
        where TControl2 : Control
    {
        var stackPanel = new StackPanel
        {
            Children =
            {
                control,
                control2
            }
        };
        
        return stackPanel;
    }
}