using ProjectManagement.Database.Adapter.Entities;
using ProjectManagement.Database.Adapter.Exceptions;
using ProjectManagement.Database.Adapter.Extensions;
using ProjectManagement.Database.Adapter.Mappers;
using ProjectManagement.Port.Repositories;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Database.Adapter.Repositories;

public class ProjectTaskRepository: IProjectTaskRepository
{
    private readonly IAppDbContext _context;

    public ProjectTaskRepository(IAppDbContext context)
    {
        _context = context; 
    }

    public async Task<ProjectTask> InsertAsync(ProjectTask task)
    {
        var sql = """
                  INSERT INTO task(project_key, name, description, due_date, status)
                  VALUES (@ProjectKey, @Name, @Description, @DueDate, @Status)
                  RETURNING id, project_key, "name", "description", due_date, "status";
                  """;

        try
        {
            return (await _context.InsertAsync<ProjectTaskEntity>(sql, task)).ToProjectTask();
        }
        catch (Exception)
        {
            throw BadRequestException.ForInsertionFailed();
        }
    }
}
