namespace ProjectManagement.Protocol.Models;

public record ProjectTask(
    Guid Id,
    string ProjectKey,
    string Name,
    string Description,
    DateTime? DueDate,
    string Status
);
