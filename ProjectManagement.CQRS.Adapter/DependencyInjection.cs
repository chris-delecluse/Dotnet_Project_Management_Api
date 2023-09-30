using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagement.CQRS.Adapter;

public static class DependencyInjection
{
    public static IServiceCollection RegisterCqrsAdapterServices(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        
        return service;
    }
}
