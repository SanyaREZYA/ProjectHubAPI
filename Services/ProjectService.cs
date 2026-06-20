using ProjectHubApi.DTOs;
using ProjectHubApi.Models;
using ProjectHubApi.Repositories;

namespace ProjectHubApi.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(
        IProjectRepository repository)
    {
        _repository = repository;
    }

    public List<Project> GetAll()
    {
        return _repository.GetAll();
    }

    public Project Create(
        CreateProjectDto dto)
    {
        var project = new Project
        {
            Name = dto.Name
        };

        return _repository.Add(project);
    }
}