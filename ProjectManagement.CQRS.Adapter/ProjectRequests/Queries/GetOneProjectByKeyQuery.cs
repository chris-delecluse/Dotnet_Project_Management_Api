using MediatR;
using ProjectManagement.Protocol.Models;

namespace ProjectManagement.CQRS.Adapter.ProjectRequests.Queries;

 public record GetOneProjectByKeyQuery(string Key) : IRequest<Result<Project>>;