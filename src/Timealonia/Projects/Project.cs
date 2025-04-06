using System.Collections.Immutable;
using Timealonia.Utilities;

namespace Timealonia.Projects;

public record Project(string Name, string Description, string Icon, string Color, IImmutableList<TimealoniaTask> Tasks)
{
    public static ProjectBuilder Empty => new();
    
    public ProjectBuilder Copy() => ProjectBuilder.FromProject(this);

    public static Option<Project> Create(string name, string description, string icon, string color, IEnumerable<TimealoniaTask> tasks)
    {
        if (ProjectValidation.IsNameValid(name) &&
            ProjectValidation.IsDescriptionValid(description) &&
            ProjectValidation.IsIconValid(icon) &&
            ProjectValidation.IsColorValid(color))
        {
            return new Project(name, description, icon, color, tasks.ToImmutableList());
        }
        return Option<Project>.None();
    }
}