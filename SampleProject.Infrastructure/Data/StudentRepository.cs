using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SampleProject.Core.Contracts;
using SampleProject.Core.Entities;
using System.Linq;

namespace SampleProject.Infrastructure.Data
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Student> GetStudentWithRegisteredCourses(int studentId)
        {
            var result = await _connection.QueryMultipleAsync("GetStudentWithRegisteredCourses", new { StudentId = studentId },
                commandType: CommandType.StoredProcedure);

            var student = result.Read<Student>().FirstOrDefault();
            student.RegisteredCourses = result.Read<RegisteredCourse>().ToList();

            return student;
        }
    }
}