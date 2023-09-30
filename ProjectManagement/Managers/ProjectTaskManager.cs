using ProjectManagement.Port.Managers;
using ProjectManagement.Port.Repositories;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Managers;

public class ProjectTaskManager : IProjectTaskManager
{
    private readonly IProjectTaskRepository _projectTaskRepository;
    
    public ProjectTaskManager(IProjectTaskRepository projectTaskRepository)
    {
        _projectTaskRepository = projectTaskRepository;
    }

    public async Task<ProjectTask> CreateTaskAsync(ProjectTask task) 
        => await _projectTaskRepository.InsertAsync(task);
}
