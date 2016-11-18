using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Interfaces;

namespace Exam.Core
{
    public class CommandInterpreter : IInterpreter
    {
        // create a field and propery for the general class here to make changes to it

        public ICommand InterpretCommand(string commandName, string[] arguments)
        {
            ICommand command = null;

            switch (commandName)
            {
                case "CommandType1":
                    break;
                case "CommandType2":
                    break;
                case "CommandType3":
                    break;
                case "CommandType4":
                    break;
                case "CommandType5":
                    break;
                case "CommandType6":
                    break;
                case "CommandType7":
                    break;
            }
            return command;
        }
    }
}