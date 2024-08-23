using MHTester.api.Common.Errors;
using MHTester.api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MHTester.api;

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