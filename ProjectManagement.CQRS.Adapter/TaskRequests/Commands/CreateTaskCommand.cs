using MediatR;
using ProjectManagement.Protocol.Enums;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.TaskRequests.Commands;

public record CreateTaskCommand(
    string ProjectKey,
    string Name,
    string Description,
    ETaskStatus Status,
    DateTime? DueDate
) : IRequest<Result<ProjectTask>>;
