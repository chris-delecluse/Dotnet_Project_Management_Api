using MediatR;
using ProjectManagement.Port.Managers;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.ProjectRequests.Commands;

internal sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<Project>>
{
    private readonly IProjectManager _projectManager;

    public CreateProjectCommandHandler(IProjectManager projectManager) => _projectManager = projectManager;

    public async Task<Result<Project>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Key)) 
            throw new ArgumentNullException(request.Key);

        if (string.IsNullOrWhiteSpace(request.Name)) 
            throw new ArgumentNullException(request.Name);

        if (string.IsNullOrWhiteSpace(request.Description)) 
            throw new ArgumentNullException(request.Description);

        try
        {
            var project = await _projectManager.CreateProjectAsync(new(request.Key,
                    request.Name,
                    request.Description,
                    DateTime.UtcNow,
                    request.DueDate ?? null
                )
            );
            
            return Result<Project>.Success(project);
        }
        catch (Exception e)
        {
            return Result<Project>.Failure(e.Message);
        }
    }
}
