using ProjectHubApi.Models;

namespace ProjectHubApi.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project> AddAsync(Project project);
    Task<Project?> UpdateAsync(int id, string name);
    Task<bool> DeleteAsync(int id);
}