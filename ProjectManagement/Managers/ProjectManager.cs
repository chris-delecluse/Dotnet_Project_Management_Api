using ProjectManagement.Port.Managers;
using ProjectManagement.Port.Repositories;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Managers;

public class ProjectManager : IProjectManager
{
    private readonly IProjectRepository _projectRepository;

    public ProjectManager(IProjectRepository projectRepository)
        => _projectRepository = projectRepository;

    public async Task<Project> CreateProjectAsync(Project project) 
        => await _projectRepository.InsertAsync(project);
    
    public async Task<IEnumerable<Project>> GetProjectsAsync()
        => await _projectRepository.FindAsync();

    public async Task<Project> GetProjectAsync(string key) 
        => await _projectRepository.FindAsync(key);
}
