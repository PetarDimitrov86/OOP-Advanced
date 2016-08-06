using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Executor
{
    public static class SessionData
    {
        public static string currentPath = Directory.GetCurrentDirectory();
        public static HashSet<Task> taskPool = new HashSet<Task>();
    }
}
