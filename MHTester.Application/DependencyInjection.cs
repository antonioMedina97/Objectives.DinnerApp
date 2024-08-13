using MHTester.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace MHTester.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}