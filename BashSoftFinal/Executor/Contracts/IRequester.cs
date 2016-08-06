using System.Collections.Generic;

namespace Executor.Contracts
{
    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string username);

        void GetStudentsByCourse(string courseName);

        ISimpleOrderedBag<Course> GetAllCoursesSorted(IComparer<Course> cmp);

        ISimpleOrderedBag<Student> GetAllStudentsSorted(IComparer<Student> cmp);
    }
}
