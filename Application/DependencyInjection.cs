using Application.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(x =>
        x.RegisterServicesFromAssemblies(typeof(GetProductsQueryHandler).Assembly, typeof(GetProductsQuery).Assembly));
        return services;
    }
}
