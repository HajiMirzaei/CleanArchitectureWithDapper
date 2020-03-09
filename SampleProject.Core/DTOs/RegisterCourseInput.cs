using System.Collections.Generic;

namespace SampleProject.Core.DTOs
{
    public class RegisterCourseInput
    {
        public int StudentId { get; set; }
        public List<int> SelectedCourseCodes { get; set; }
        public RegisterCourseInput()
        {
        }

        public RegisterCourseInput(int studentId, List<int> selectedCourseCodes)
        {
            StudentId = studentId;
            SelectedCourseCodes = selectedCourseCodes;
        }
    }
}