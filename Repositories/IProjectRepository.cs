using ProjectHubApi.Models;

namespace ProjectHubApi.Repositories;

public interface IProjectRepository
{
    List<Project> GetAll();

    Project? GetById(int id);

    Project Add(Project project);
}