using MediatR;
using ProjectManagement.Port.Managers;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.ProjectRequests.Queries;

internal sealed class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, Result<IEnumerable<Project>>>
{
    private readonly IProjectManager _projectManager;

    public GetAllProjectQueryHandler(IProjectManager projectManager) => _projectManager = projectManager;

    public async Task<Result<IEnumerable<Project>>> Handle(
        GetAllProjectQuery request,
        CancellationToken cancellationToken
    ) =>
        Result<IEnumerable<Project>>.Success(await _projectManager.GetProjectsAsync());
}
