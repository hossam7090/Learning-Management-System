using FluentValidation;
using Lms.Core.Behaviors;
using Lms.Infrastructure.Repositories.Abstracts;
using Lms.Infrastructure.Repositories.implementation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Lms.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
