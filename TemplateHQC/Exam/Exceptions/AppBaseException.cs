using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Exceptions
{
    public abstract class AppBaseException : Exception
    {
        protected AppBaseException()
        {
        }

        protected AppBaseException(string message)
            : base(message)
        {
        }
    }
}