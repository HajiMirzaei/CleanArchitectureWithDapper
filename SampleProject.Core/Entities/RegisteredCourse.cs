using SampleProject.Core.Contracts;

namespace SampleProject.Core.Entities
{
    public class RegisteredCourse : EntityBase
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
