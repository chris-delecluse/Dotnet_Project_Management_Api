using ProjectManagement.Protocol.Models;
using ProjectManagement.Web.Api.Dto;

namespace ProjectManagement.Web.Api.Mappers;

internal static class ProjectTaskDtoMapper
{
    internal static ProjectTaskDto ToProjectTaskDto(this ProjectTask projectTask) =>
        new(projectTask.Id,
            projectTask.ProjectKey,
            projectTask.Name,
            projectTask.Description,
            projectTask.Status.ToString(),
            projectTask.DueDate
        );
}
