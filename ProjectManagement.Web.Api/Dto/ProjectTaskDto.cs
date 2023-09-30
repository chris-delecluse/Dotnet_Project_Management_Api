using ProjectManagement.Protocol.Enums;

namespace ProjectManagement.Web.Api.Dto;

public record ProjectTaskDto(
    Guid Id,
    string ProjectKey,
    string Name,
    string Description,
    string Status,
    DateTime? DueDate
);
