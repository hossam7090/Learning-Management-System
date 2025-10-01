using Lms.Services.Abstracts;
using Lms.Services.implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Lms.Services
{
    public static class ModuleServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }

    }
}
