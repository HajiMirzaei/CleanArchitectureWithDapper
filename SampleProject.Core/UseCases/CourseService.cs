using SampleProject.Core.Contracts;
using SampleProject.Core.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Core.UseCases
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;
        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<RegisterCourseOutput> RegisterCourse(RegisterCourseInput arg)
        {
            var student = await _uow.StudentRepository.GetStudentWithRegisteredCourses(arg.StudentId);

            var errors = new List<string>();
            foreach (var item in arg.SelectedCourseCodes)
            {
                var course = await _uow.CourseRepository.GetByIdAsync(item);
                var res = student.RegisterForCourse(course);
                if (!res)
                {
                    errors.Add($"unable to register for {course.Name}");
                }
                else
                {
                    var registerCourse = new Entities.RegisteredCourse()
                    {
                        StudentId = arg.StudentId,
                        CourseId = course.Id
                    };
                    _uow.RegisteredCourseRepository.AddAsync(registerCourse);
                }
            }

            return new RegisterCourseOutput(!errors.Any(), errors);
        }
    }
}