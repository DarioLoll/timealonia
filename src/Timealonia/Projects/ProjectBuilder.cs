using Timealonia.Todos;
using Timealonia.Utilities;

namespace Timealonia.Projects;

public class ProjectBuilder
{
    public static ProjectBuilder Create()
    {
        return new ProjectBuilder();
    }
    
    public static ProjectBuilder FromProject(Project project)
    {
        return Create()
            .WithName(project.Name)
            .WithDescription(project.Description)
            .WithIcon(project.Icon)
            .WithColor(project.Color)
            .WithTodos(project.Todos);
    }
    
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Icon { get; private set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public IEnumerable<Todo> Todos { get; private set; } = [];
    
    public ProjectBuilder WithName(string name)
    {
        Name = name;
        return this;
    }
    public ProjectBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }
    public ProjectBuilder WithIcon(string icon)
    {
        Icon = icon;
        return this;
    }
    public ProjectBuilder WithColor(string color)
    {
        Color = color;
        return this;
    }
    public ProjectBuilder WithTodos(IEnumerable<Todo> tasks)
    {
        Todos = tasks;
        return this;
    }
    public ProjectBuilder WithTodo(Todo task)
    {
        Todos = Todos.Append(task);
        return this;
    }
    public ProjectBuilder WithTodo(string name, string description = "", int? number = null)
    {
        var num = number ?? Todos.Max(todo => todo.Number) + 1;
        var todo = Todo.Create(num, name, description);
        Todos = Todos.Append(todo);
        return this;
    }
    
    public Option<Project> Build()
    {
        return Project.Create(Name, Description, Icon, Color, Todos);
    }
}