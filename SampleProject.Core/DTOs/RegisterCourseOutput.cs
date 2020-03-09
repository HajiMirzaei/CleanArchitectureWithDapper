using SampleProject.Core.Contracts;
using System.Collections.Generic;

namespace SampleProject.Core.DTOs
{
    public class RegisterCourseOutput : ResponseMessage
    {
        public List<string> Errors { get; private set; }
        public RegisterCourseOutput(bool success, List<string> errors, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
