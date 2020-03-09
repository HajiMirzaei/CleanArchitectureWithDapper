using Microsoft.Extensions.DependencyInjection;
using SampleProject.Core.Contracts;
using SampleProject.Infrastructure.Data;

namespace SampleProject.Infrastructure.IoC
{
    public static class ServiceModuleExtentions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<ICourseRepository, CourseRepository>();
            serviceCollection.AddTransient<IStudentRepository, StudentRepository>();
            serviceCollection.AddTransient<IRegisteredCourseRepository, RegisteredCourseRepository>();
        }
    }
}