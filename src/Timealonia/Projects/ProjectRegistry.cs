using Timealonia.Utilities;

namespace Timealonia.Projects;

public class ProjectRegistry : IProjectRegistry
{
    private readonly List<Project> _projects = new();
    
    public IEnumerable<Project> GetProjects() => _projects;

    public Option<Project> GetProject(string name) => _projects.FirstOrNone(p => p.Name == name);

    public Result AddProject(Project project)
    {
        if (_projects.Any(p => p.Name == project.Name))
            return Result.Fail($"Project with name {project.Name} already exists.");
        _projects.Add(project);
        ProjectsChanged?.Invoke();
        return Result.Success();
    }

    public Result UpdateProject(string name, Project project)
    {
        var index = _projects.FindIndex(p => p.Name == name);
        if (index == -1)
            return Result.Fail($"Project with name {name} not found.");
        _projects[index] = project;
        ProjectsChanged?.Invoke();
        return Result.Success();
    }

    public Result DeleteProject(string name)
    {
        return _projects.RemoveAll(p => p.Name == name) > 0
            ? Result.Success()
            : Result.Fail($"Project with name {name} not found.");
    }

    public event Action? ProjectsChanged;
}