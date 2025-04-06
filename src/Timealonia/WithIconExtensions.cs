using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using HarfBuzzSharp;
using Projektanker.Icons.Avalonia;
using Timealonia.Components;

namespace Timealonia;

public enum IconPlacement
{
    Left,
    Right,
    Top,
    Bottom
}

public static class WithIconExtensions
{
    public static StackPanel WithIcon<TControl>(this TControl control, string iconName, IconPlacement placement = IconPlacement.Left) 
        where TControl : Control 
        => control.WithIcon(new Ico(iconName), placement);
    
    public static StackPanel WithIcon<TControl>(this TControl control, Icon icon, IconPlacement placement = IconPlacement.Left) 
        where TControl : Control 
        => control.NextTo(icon, placement);

    public static StackPanel NextTo<TControl, TControl2>(this TControl control, TControl2 control2,
        IconPlacement placement = IconPlacement.Left)
        where TControl : Control
        where TControl2 : Control
    {
        var stackPanel = placement switch
        {
            IconPlacement.Left or IconPlacement.Top => control.PlaceBefore(control2),
            IconPlacement.Right or IconPlacement.Bottom => control.PlaceAfter(control2),
            _ => throw new ArgumentOutOfRangeException(nameof(placement), placement, null)
        };
        stackPanel.Orientation = placement is IconPlacement.Left or IconPlacement.Right
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