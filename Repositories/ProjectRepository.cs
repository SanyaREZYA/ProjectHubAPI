using ProjectHubApi.Data;
using ProjectHubApi.Models;

namespace ProjectHubApi.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly InMemoryDatabase _database;

    public ProjectRepository(
        InMemoryDatabase database)
    {
        _database = database;
    }

    public List<Project> GetAll()
    {
        return _database.Projects;
    }

    public Project Add(Project project)
    {
        project.Id =
            _database.Projects.Max(p => p.Id) + 1;

        _database.Projects.Add(project);

        return project;
    }

    public Project? GetById(int id)
    {
        return _database.Projects
            .FirstOrDefault(
                p => p.Id == id);
    }
}