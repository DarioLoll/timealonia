using System.Text.Json;
using Avalonia.Markup.Declarative;
using Timealonia.Projects;

namespace Timealonia.Persistance;

public class AppDataStore
{
    private readonly IProjectRegistry _projectRegistry;

    public AppDataStore(IProjectRegistry projectRegistry)
    {
        _projectRegistry = projectRegistry;
    }

    public async Task LoadAppDataAsync()
    {
        if (!File.Exists("projects.json")) return;
        
        var json = await File.ReadAllTextAsync("projects.json");
        var projects = JsonSerializer.Deserialize<List<Project>>(json);
        if (projects == null) throw new Exception("Projects were null");
        projects.ForEach(p => _projectRegistry.AddProject(p));
    }
    
    public async Task SaveAsync()
    {
        var projects = _projectRegistry.GetProjects();
        var json = JsonSerializer.Serialize(projects);
        await File.WriteAllTextAsync("projects.json", json);
    }
}