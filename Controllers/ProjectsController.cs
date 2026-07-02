using Microsoft.AspNetCore.Mvc;
using ProjectHubApi.DTOs;
using ProjectHubApi.Services;
using ProjectHubApi.Models;

namespace ProjectHubApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;
    private readonly ILogger<ProjectsController> _logger;

    public ProjectsController(IProjectService service, ILogger<ProjectsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<Project>>> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Project>> Create(CreateProjectDto dto)
    {
        var created = await _service.CreateAsync(dto);

        return Created($"/api/projects/{created.Id}", created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Project>> Update(int id, UpdateProjectDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}
