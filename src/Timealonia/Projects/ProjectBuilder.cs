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
            .WithTasks(project.Tasks);
    }
    
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Icon { get; private set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public IEnumerable<TimealoniaTask> Tasks { get; private set; } = [];
    
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
    public ProjectBuilder WithTasks(IEnumerable<TimealoniaTask> tasks)
    {
        Tasks = tasks;
        return this;
    }
    public ProjectBuilder WithTask(TimealoniaTask task)
    {
        Tasks = Tasks.Append(task);
        return this;
    }
    
    public Option<Project> Build()
    {
        return Project.Create(Name, Description, Icon, Color, Tasks);
    }
}