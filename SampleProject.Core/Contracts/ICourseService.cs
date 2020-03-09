using SampleProject.Core.DTOs;
using System.Threading.Tasks;

namespace SampleProject.Core.Contracts
{
    public interface ICourseService
    {
        Task<RegisterCourseOutput> RegisterCourse(RegisterCourseInput arg);
    }
}