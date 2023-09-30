using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Port.Repositories;

public interface IProjectRepository
{
    Task<Project> InsertAsync(Project options);
    Task<IEnumerable<Project>> FindAsync();
    Task<Project> FindAsync(string key);
}
