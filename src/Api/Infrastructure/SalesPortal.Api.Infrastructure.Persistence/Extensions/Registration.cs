using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesPortal.Api.Application.Interfaces.Repositories;
using SalesPortal.Api.Infrastructure.Persistence.Context;
using SalesPortal.Api.Infrastructure.Persistence.Repositories;

namespace SalesPortal.Api.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(conf =>
        {
            conf.UseSqlServer(configuration.GetConnectionString("SalesPortalConnectionString"));
        });


        services.AddScoped<IEnvaterRepository, EnvanterRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISalesUnitRepository, SalesUnitRepository>();

        return services;
    }
}
