using ProjectHubApi.Models;
using ProjectHubApi.Repositories;
using ProjectHubApi.DTOs;

namespace ProjectHubApi.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Project>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Project?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task<Project> CreateAsync(CreateProjectDto dto)
    {
        var project = new Project
        {
            Name = dto.Name
        };

        return await _repository.AddAsync(project);
    }

    public async Task<Project?> UpdateAsync(int id, UpdateProjectDto dto)
    {
        if (dto.Name is null)
            return await _repository.GetByIdAsync(id);

        return await _repository.UpdateAsync(id, dto.Name);
    }

    public async Task<bool> DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}