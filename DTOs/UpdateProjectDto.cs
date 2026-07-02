using System.ComponentModel.DataAnnotations;

namespace ProjectHubApi.DTOs;

public class UpdateProjectDto
{
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }
}