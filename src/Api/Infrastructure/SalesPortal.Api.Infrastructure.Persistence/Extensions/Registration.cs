using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesPortal.Api.Infrastructure.Persistence.Context;

namespace SalesPortal.Api.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(conf =>
        {
            conf.UseSqlServer(configuration.GetConnectionString("SalesPortalConnectionString"));
        });

        return services;
    }
}
