using ProjectHubApi.DTOs;
using ProjectHubApi.Models;

namespace ProjectHubApi.Services;

public interface IProjectService
{
    List<Project> GetAll();

    Project Create(CreateProjectDto dto);
}