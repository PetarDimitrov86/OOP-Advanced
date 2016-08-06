using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Contracts
{
    public interface IFilteredTaker
    {
        void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null);
    }
}
