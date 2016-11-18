using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Core;
using Exam.Interfaces;

namespace Exam
{
    public class Startup
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}