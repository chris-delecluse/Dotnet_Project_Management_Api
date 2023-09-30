using Carter;
using MediatR;
using ProjectManagement.CQRS.Adapter.ProjectRequests.Commands;
using ProjectManagement.CQRS.Adapter.ProjectRequests.Queries;
using ProjectManagement.Web.Api.Mappers;

namespace ProjectManagement.Web.Api.Endpoints;

public class ProjectModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/project");

        group.MapGet("",
            async (ISender sender) =>
                Results.Ok((await sender.Send(new GetAllProjectQuery())).Data?.Select(p => p.ToProjectDto()))
        );

        group.MapGet("{key}",
            async (string key, ISender sender) =>
            {
                var projectResult = await sender.Send(new GetOneProjectByKeyQuery(key));

                return projectResult.IsSuccess
                    ? Results.Ok(projectResult.Data?.ToProjectDto())
                    : Results.NotFound(projectResult.ErrorMessage);
            }
        );

        group.MapPost("",
            async (CreateProjectCommand command, ISender sender) =>
                Results.Created("", (await sender.Send(command)).Data?.ToProjectDto())
        );
    }
}
