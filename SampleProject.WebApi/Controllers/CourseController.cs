using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Core.Contracts;
using SampleProject.Core.DTOs;

namespace SampleProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        protected readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("[action]")]
        public async Task<RegisterCourseOutput> RegisterCourse(RegisterCourseInput args)
        {
            var result = await _courseService.RegisterCourse(args);
            return result;
        }
    }
}