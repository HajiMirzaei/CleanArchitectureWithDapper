using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Core.Contracts;
using SampleProject.Core.DTOs;

namespace SampleProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        protected readonly ICourseService _courseService;
        public StudentController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("[action]")]
        public async Task<RegisterCourseOutput> Index(RegisterCourseInput args)
        {
            var result = await _courseService.RegisterCourse(args);
            return result;
        }
    }
}