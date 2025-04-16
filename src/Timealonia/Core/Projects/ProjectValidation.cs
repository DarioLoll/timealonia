using Projektanker.Icons.Avalonia.MaterialDesign;

namespace Timealonia.Core.Projects;

public static class ProjectValidation
{
    public static bool IsNameValid(string projectName)
    {
        return !string.IsNullOrWhiteSpace(projectName);
    }
    
    public static bool IsDescriptionValid(string projectDescription)
    {
        return !string.IsNullOrWhiteSpace(projectDescription);
    }
    
    public static bool IsIconValid(string projectIcon)
    {
        var iconProvider = new MaterialDesignIconProvider();
        try
        {
            var icon = iconProvider.GetIcon($"mdi-{projectIcon}");
            return icon != null;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool IsColorValid(string projectColor)
    {
        //Format #RRGGBB
        if (projectColor.Length != 7)
            return false;
        if (projectColor[0] != '#')
            return false;
        for (int i = 1; i < projectColor.Length; i++)
        {
            if (!char.IsDigit(projectColor[i]) && (projectColor[i] < 'A' || projectColor[i] > 'F'))
                return false;
        }
        return true;
    }
}