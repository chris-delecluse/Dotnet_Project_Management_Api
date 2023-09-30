using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Port.Managers;

public interface IProjectManager
{
    Task<Project> CreateProjectAsync(Project project);
    Task<IEnumerable<Project>> GetProjectsAsync();
    Task<Project> GetProjectAsync(string key);
}
