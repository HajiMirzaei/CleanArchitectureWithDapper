using Microsoft.Extensions.DependencyInjection;
using SampleProject.Core.Contracts;
using SampleProject.Core.UseCases;

namespace SampleProject.Core.IoC
{
    public static class ServiceModuleExtentions
    {
        public static void RegisterCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICourseService, CourseService>();
        }
    }
}
