using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Database.Adapter.Repositories;
using ProjectManagement.Port.Repositories;

namespace ProjectManagement.Database.Adapter;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDatabaseAdapterServices(this IServiceCollection service)
    {
        service.AddSingleton<IAppDbContext, AppDbContext>();

        service.AddScoped<IProjectRepository, ProjectRepository>();
        service.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
        
        return service;
    }
}
