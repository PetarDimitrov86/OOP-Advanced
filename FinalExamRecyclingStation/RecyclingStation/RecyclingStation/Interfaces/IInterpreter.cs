using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingStation.Interfaces
{
    public interface IInterpreter
    {
        // Hold the General system class here

        ICommand InterpretCommand(string commandName, string[] arguments);
    }
}
