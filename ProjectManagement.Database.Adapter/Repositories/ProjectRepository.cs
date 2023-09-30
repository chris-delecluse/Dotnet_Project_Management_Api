using ProjectManagement.Database.Adapter.Entities;
using ProjectManagement.Database.Adapter.Exceptions;
using ProjectManagement.Database.Adapter.Extensions;
using ProjectManagement.Database.Adapter.Mappers;
using ProjectManagement.Port.Repositories;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Database.Adapter.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly IAppDbContext _context;

    public ProjectRepository(IAppDbContext context) { _context = context; }

    public async Task<Project> InsertAsync(Project options)
    {
        var sql = """
                  INSERT INTO project("key", name, description, start_date, due_date)
                  VALUES (@Key, @Name, @Description, @StartDate, @DueDate)
                  RETURNING *;
                  """;

        try
        {
            return (await _context.InsertAsync<ProjectEntity>(sql, options)).ToProject();
        }
        catch (Exception)
        {
            throw BadRequestException.ForInsertionFailed();
        }
    }

    public async Task<IEnumerable<Project>> FindAsync()
    {
        var sql = """
                  SELECT id, "key", name, description, start_date, due_date FROM project;
                  """;

        return (await _context.FindAsync<ProjectEntity>(sql)).Select(p => p.ToProject());
    }

    public async Task<Project> FindAsync(string key)
    {
        var sql = """
                  SELECT id, "key", name, description, start_date, due_date FROM project
                  WHERE "key" = @Key;
                  """;

        try
        {
            return (await _context.FindAsync<ProjectEntity>(sql, new { Key = key }))
                .Single()
                .ToProject();
        }
        catch (Exception)
        {
            throw NotFoundException.ForMissingEntity(key);
        }
    }
}
