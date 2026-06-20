using Microsoft.AspNetCore.Mvc;
using ProjectHubApi.DTOs;
using ProjectHubApi.Services;

namespace ProjectHubApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(
        IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetProjects()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult CreateProject(
        CreateProjectDto dto)
    {
        var created =
            _service.Create(dto);

        return Created(
            $"/api/projects/{created.Id}",
            created);
    }
}