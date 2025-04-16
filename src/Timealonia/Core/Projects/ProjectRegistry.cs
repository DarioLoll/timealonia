using System.Collections.Immutable;
using Timealonia.Core.Utilities;

namespace Timealonia.Core.Projects;

public record ProjectRegistry(ImmutableList<Project> Projects);

public static class ProjectRegistryFunctions
{
    public static Option<Project> FindByName(this ProjectRegistry pr, string name) 
        => pr.Projects.FirstOrNone(p => p.Name == name);

    public static Option<ProjectRegistry> AddProject(this ProjectRegistry pr, Project project)
    {
        if (pr.Projects.Any(p => p.Name == project.Name))
            return Option<ProjectRegistry>.None();
        return new ProjectRegistry(Projects: pr.Projects.Add(project));
    }

    public static Option<ProjectRegistry> UpdateProject(this ProjectRegistry pr, string name, Project project)
    {
        return pr.FindByName(name)
            .Map(proj => pr.Projects.Replace(proj, project))
            .Map(projects => new ProjectRegistry(Projects: projects));
    }

    public static Option<ProjectRegistry> DeleteProject(this ProjectRegistry pr, string name)
    {
        return pr.FindByName(name)
            .Map(proj => pr.Projects.Remove(proj))
            .Map(projects => new ProjectRegistry(Projects: projects));
    }
}