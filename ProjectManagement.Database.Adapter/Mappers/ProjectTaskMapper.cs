using ProjectManagement.Database.Adapter.Entities;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Database.Adapter.Mappers;

internal static class ProjectTaskMapper
{
    internal static ProjectTask ToProjectTask(this ProjectTaskEntity entity) =>
        new(entity.Id, entity.ProjectKey, entity.Name, entity.Description, entity.DueDate, entity.Status);
}
