using System;
using System.Collections.Generic;

namespace Executor.Contracts
{
    public interface Student : IComparable<Student>
    {
        string UserName { get; }
        IReadOnlyDictionary<string, Course> EnrolledCourses { get; }
        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        void EnrollInCourse(Course course);
        void SetMarkOnCourse(string courseName, params int[] scores);
        string GetMarkForCourse(string courseName);
    }
}
