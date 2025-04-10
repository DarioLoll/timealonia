using Timealonia.Utilities;

namespace Timealonia.Projects;

public interface IProjectRegistry
{
    IEnumerable<Project> GetProjects();
    Option<Project> GetProject(string name);
    Result AddProject(Project project);
    Result UpdateProject(string name, Project project);
    Result DeleteProject(string name);
    event Action? ProjectsChanged;
}