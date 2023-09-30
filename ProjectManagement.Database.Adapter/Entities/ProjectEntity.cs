namespace ProjectManagement.Database.Adapter.Entities;

public record ProjectEntity(
    Guid Id,
    string Key,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime? DueDate
);
