using Carter;
using MediatR;
using ProjectManagement.CQRS.Adapter.TaskRequests.Commands;
using ProjectManagement.Web.Api.Mappers;

namespace ProjectManagement.Web.Api.Endpoints;

public class TaskModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/task");

        group.MapPost("",
            async (CreateTaskCommand command, ISender sender) =>
            {
                var taskResult = await sender.Send(command);

                return taskResult.IsSuccess
                    ? Results.Ok(taskResult.Data?.ToProjectTaskDto())
                    : Results.BadRequest(taskResult.ErrorMessage);
            }
        );
    }
}
