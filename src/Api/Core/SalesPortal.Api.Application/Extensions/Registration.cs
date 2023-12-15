using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SalesPortal.Api.Application.Extensions;

public static class Registration
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        var asm = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(asm));
        services.AddAutoMapper(asm);

        return services;
    }
}
