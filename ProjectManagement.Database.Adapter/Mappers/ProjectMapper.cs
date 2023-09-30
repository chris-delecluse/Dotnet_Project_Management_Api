using ProjectManagement.Database.Adapter.Entities;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.Database.Adapter.Mappers;

internal static class ProjectMapper
{
    internal static Project ToProject(this ProjectEntity entity) =>
        new(entity.Key, entity.Name, entity.Description, entity.StartDate, entity.DueDate);
}
