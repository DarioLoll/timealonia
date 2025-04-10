using System.Collections.Immutable;
using Timealonia.Todos;
using Timealonia.Utilities;

namespace Timealonia.Projects;

public record Project(string Name, string Description, string Icon, string Color, IImmutableList<Todo> Todos)
{
    public static ProjectBuilder Empty => new();
    
    public ProjectBuilder Copy() => ProjectBuilder.FromProject(this);

    public static Option<Project> Create(string name, string description, string icon, string color, IEnumerable<Todo> todos)
    {
        if (ProjectValidation.IsNameValid(name) &&
            ProjectValidation.IsDescriptionValid(description) &&
            ProjectValidation.IsIconValid(icon) &&
            ProjectValidation.IsColorValid(color))
        {
            return new Project(name, description, icon, color, todos.ToImmutableList());
        }
        return Option<Project>.None();
    }
}