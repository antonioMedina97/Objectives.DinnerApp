using System.Reflection;
using FluentValidation;
using MediatR;
using MHTester.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace MHTester.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}