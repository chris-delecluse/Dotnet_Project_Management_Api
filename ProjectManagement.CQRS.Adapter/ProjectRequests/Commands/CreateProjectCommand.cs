using MediatR;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.ProjectRequests.Commands;

public record CreateProjectCommand(
    string Key,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime? DueDate
) : IRequest<Result<Project>>;
