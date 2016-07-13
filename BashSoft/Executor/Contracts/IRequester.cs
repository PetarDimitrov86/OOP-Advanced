using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Contracts
{
    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string username);
        void GetStudentsByCourse(string courseName);
    }
}
