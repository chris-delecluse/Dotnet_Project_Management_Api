using ProjectManagement.Protocol.Enums;

namespace ProjectManagement.Database.Adapter.Entities;

public record ProjectTaskEntity(
    Guid Id,
    string ProjectKey,
    string Name,
    string Description,
    DateTime DueDate,
    string Status
);
