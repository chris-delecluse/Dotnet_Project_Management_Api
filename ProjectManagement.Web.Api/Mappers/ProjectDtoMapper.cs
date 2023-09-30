using ProjectManagement.Protocol.Models;
using ProjectManagement.Web.Api.Dto;

namespace ProjectManagement.Web.Api.Mappers;

internal static class ProjectDtoMapper
{
    internal static ProjectDto ToProjectDto(this Project project) =>
        new(project.Key, project.Name, project.Description, project.StartDate, project.DueDate);
}
