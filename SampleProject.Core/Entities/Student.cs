using SampleProject.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject.Core.Entities
{
    public class Student : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<RegisteredCourse> RegisteredCourses { get; set; }

        public Student()
        {
            RegisteredCourses = new List<RegisteredCourse>();
        }

        public bool RegisterForCourse(Course course)
        {
            // student has not previously registered
            if (RegisteredCourses.Any(ec => ec.CourseId == course.Id)) return false;

            // registratraion cannot occur with 5 days of course start date
            if (DateTime.UtcNow < course.StartDate.AddDays(-5)) return false;

            return true;
        }
    }
}
