using MediatR;
using ProjectManagement.Port.Managers;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.ProjectRequests.Queries;

internal sealed class GetOneProjectByKeyQueryHandler: IRequestHandler<GetOneProjectByKeyQuery, Result<Project>>
{
    private readonly IProjectManager _projectManager;

    public GetOneProjectByKeyQueryHandler(IProjectManager projectManager)
    {
        _projectManager = projectManager;
    }

    public async Task<Result<Project>> Handle(GetOneProjectByKeyQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Key)) 
            throw new ArgumentNullException(request.Key);

        try
        {
            return Result<Project>.Success(await _projectManager.GetProjectAsync(request.Key));
        }
        catch (Exception e)
        {
           return Result<Project>.Failure(e.Message);
        }
    }
}
