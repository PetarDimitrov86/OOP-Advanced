using System.Collections.Generic;
using LambdaCore_Skeleton.Interfaces;
using LambdaCore_Skeleton.Models.Cores;

namespace LambdaCore_Skeleton
{
    using System;
    using Collection;

    public class Startup
    {
        static void Main()
        {
            List<ICore> repository = new List<ICore>();
            CommandInterpreter interpreter = new CommandInterpreter();
            string input = Console.ReadLine();
            while (input != "System Shutdown!")
            {
                var command = interpreter.InterpredCommand(input, repository);
                command.Execute();
                input = Console.ReadLine();
            }

        }
    }
}