namespace ProjectManagement.Web.Api.Dto;

public record ProjectDto(
    string Key,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime? DueDate
);
