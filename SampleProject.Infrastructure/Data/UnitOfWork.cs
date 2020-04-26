using SampleProject.Core.Contracts;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SampleProject.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
        }

        public IStudentRepository StudentRepository => _serviceProvider.GetService<IStudentRepository>();
        public ICourseRepository CourseRepository => _serviceProvider.GetService<ICourseRepository>();
        public IRegisteredCourseRepository RegisteredCourseRepository => _serviceProvider.GetService<IRegisteredCourseRepository>();
    }
}