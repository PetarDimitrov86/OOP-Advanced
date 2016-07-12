using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Executor.Models;

namespace Executor.Contracts
{
    public interface Course
    {
        String Name { get; }

        IReadOnlyDictionary<String, Student> StudentByName { get; }

        void EnrollStudent(Student student);
    }
}
