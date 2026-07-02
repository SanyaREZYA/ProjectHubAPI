using Microsoft.EntityFrameworkCore;
using ProjectHubApi.Data;
using ProjectHubApi.Models;

namespace ProjectHubApi.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project> AddAsync(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project?> UpdateAsync(int id, string name)
    {
        var project = await GetByIdAsync(id);
        if (project is null) return null;

        project.Name = name;
        await _context.SaveChangesAsync();

        return project;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await GetByIdAsync(id);
        if (project is null) return false;

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return true;
    }
}