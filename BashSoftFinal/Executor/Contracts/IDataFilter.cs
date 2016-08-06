using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Contracts
{
    public interface IDataFilter
    {
        void PrintFilteredStudents(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake);
    }
}
