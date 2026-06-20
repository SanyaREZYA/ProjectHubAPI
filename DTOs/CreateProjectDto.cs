using System.ComponentModel.DataAnnotations;

namespace ProjectHubApi.DTOs;

public class CreateProjectDto
{
    [Required(
        ErrorMessage =
        "Назва обов'язкова")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage =
        "Назва має бути 3–50 символів")]
    public string Name { get; set; } = "";
}