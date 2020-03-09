using System;

namespace SampleProject.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        IRegisteredCourseRepository RegisteredCourseRepository { get; }
    }
}
