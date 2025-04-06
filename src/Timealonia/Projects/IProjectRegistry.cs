namespace Timealonia.Projects;

public interface IProjectRegistry
{
    IEnumerable<Project> GetProjects();
}