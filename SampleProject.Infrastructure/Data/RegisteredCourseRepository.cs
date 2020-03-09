using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SampleProject.Core.Contracts;
using SampleProject.Core.Entities;
using System.Linq;

namespace SampleProject.Infrastructure.Data
{
    public class RegisteredCourseRepository : RepositoryBase<RegisteredCourse>, IRegisteredCourseRepository
    {
        public RegisteredCourseRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}