namespace ProjectManagement.Protocol.Models;

public record Project(
    string Key,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime? DueDate
);
