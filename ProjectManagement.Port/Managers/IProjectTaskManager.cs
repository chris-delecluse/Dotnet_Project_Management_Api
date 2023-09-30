using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Port.Managers;

public interface IProjectTaskManager
{
    Task<ProjectTask> CreateTaskAsync(ProjectTask task);
}
