using ProjectHubApi.Models;

namespace ProjectHubApi.Data;

public class InMemoryDatabase
{
    public List<Project> Projects { get; } =
    [
        new()
        {
            Id = 1,
            Name = "ProjectHub"
        },

        new()
        {
            Id = 2,
            Name = "Unity Game"
        }
    ];
}