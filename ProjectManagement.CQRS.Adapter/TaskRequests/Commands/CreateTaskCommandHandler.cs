using MediatR;
using ProjectManagement.Port.Managers;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.TaskRequests.Commands;

internal sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<ProjectTask>>
{
    private readonly IProjectTaskManager _projectTaskManager;

    public CreateTaskCommandHandler(IProjectTaskManager projectTaskManager)
    {
        _projectTaskManager = projectTaskManager;
    }

    public async Task<Result<ProjectTask>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.ProjectKey))
            throw new ArgumentNullException(request.ProjectKey);

        if (string.IsNullOrWhiteSpace(request.Name)) 
            throw new ArgumentNullException(request.Name);

        if (string.IsNullOrWhiteSpace(request.Description)) 
            throw new ArgumentNullException(request.Description);

        try
        {
            var projectTask = await _projectTaskManager.CreateTaskAsync(new ProjectTask(Guid.Empty,
                    request.ProjectKey,
                    request.Name,
                    request.Description,
                    request.DueDate,
                    request.Status.ToString()
                )
            );

            return Result<ProjectTask>.Success(projectTask);
        }
        catch (Exception e)
        {
            return Result<ProjectTask>.Failure(e.Message);
        }
    }
}
