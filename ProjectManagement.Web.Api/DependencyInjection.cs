using Carter;

namespace ProjectManagement.Web.Api;

internal static class DependencyInjection
{
    internal static IServiceCollection RegisterWebApiServices(this IServiceCollection service)
    {
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();
        
        service.AddCarter();
        
        return service;
    }
}
