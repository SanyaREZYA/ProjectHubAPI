using ProjectHubApi.DTOs;
using ProjectHubApi.Models;

namespace ProjectHubApi.Services;

public interface IProjectService
{
    Task<List<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> CreateAsync(CreateProjectDto dto);
    Task<Project?> UpdateAsync(int id, UpdateProjectDto dto);
    Task<bool> DeleteAsync(int id);
}