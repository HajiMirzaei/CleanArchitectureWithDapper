using Microsoft.Extensions.Configuration;
using SampleProject.Core.Contracts;
using SampleProject.Core.Entities;

namespace SampleProject.Infrastructure.Data
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}