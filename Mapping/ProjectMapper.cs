using ProjectHubApi.DTOs;
using ProjectHubApi.Models;

namespace ProjectHubApi.Mapping;

public static class ProjectMapper
{
    public static Project ToEntity(CreateProjectDto dto)
    {
        return new Project
        {
            Name = dto.Name
        };
    }
}