using MediatR;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.ProjectRequests.Queries;

public record GetAllProjectQuery() : IRequest<Result<IEnumerable<Project>>>;
