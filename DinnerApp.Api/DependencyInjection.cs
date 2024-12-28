using DinnerApp.Api.Common.Errors;

using DinnerApp.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DinnerApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, MHTesterProblemDetailsFactory>();
        
        return services;
    }
}