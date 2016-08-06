using System;
using System.Collections.Generic;

namespace Executor.Contracts
{
    public interface Course : IComparable<Course>
    {
        String Name { get; }

        IReadOnlyDictionary<String, Student> StudentByName { get; }

        void EnrollStudent(Student student);
    }
}
