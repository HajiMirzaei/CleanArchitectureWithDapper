using SampleProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleProject.Core.Contracts
{
    public interface IStudentRepository : IAsyncGenericRepository<Student>
    {
        Task<Student> GetStudentWithRegisteredCourses(int studentId);
    }
}
