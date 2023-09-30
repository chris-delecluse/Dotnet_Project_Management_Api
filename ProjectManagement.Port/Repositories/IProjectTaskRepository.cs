using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Port.Repositories;

public interface IProjectTaskRepository
{
    Task<ProjectTask> InsertAsync(ProjectTask task);
}
