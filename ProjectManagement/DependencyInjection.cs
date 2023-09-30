using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Managers;
using ProjectManagement.Port.Managers;

namespace ProjectManagement;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDomainServices(this IServiceCollection service)
    {
        service.AddScoped<IProjectManager, ProjectManager>();
        service.AddScoped<IProjectTaskManager, ProjectTaskManager>();
        
        return service;
    }
}
