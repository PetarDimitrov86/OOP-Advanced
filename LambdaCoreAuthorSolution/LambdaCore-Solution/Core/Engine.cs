namespace LambdaCore_Solution.Core
{
    using System;

    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.IO;
    using LambdaCore_Solution.Utilities;

    public class Engine : IEngine
    {
        private readonly IInputReader consoleReader;

        private readonly IOutputWriter consoleWriter;

        private readonly ICommandDispatcher commandInterpreter;

        private bool isRunning;

        public Engine()
        {
            this.consoleReader = new ConsoleReader();
            this.consoleWriter = new ConsoleWriter();
            this.commandInterpreter = new CommandDispatcher();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string inputLine = this.consoleReader.ReadLine();

                this.ProcessInput(inputLine);
            }
        }

        private void ProcessInput(string input)
        {
            string[] splittedArgs = input.Split(Constants.InputSplitDelimeter);

            string commandName = splittedArgs[0];

            if (commandName.Equals(Constants.InputTerminatingCommand))
            {
                this.isRunning = false;
                return;
            }

            string[] commandArgs = null;

            if (splittedArgs.Length > 1)
            {
                commandArgs = splittedArgs[1].Split(
                    new[] { Constants.InputCommandArgumentsSplitDelimeter },
                    StringSplitOptions.RemoveEmptyEntries);
            }

            try
            {
                ICommand command = this.commandInterpreter.DispatchCommand(commandName, commandArgs);

                if (command == null)
                {
                    throw new NullReferenceException("Invalid Command!");
                }

                string commandResult = command.Execute();
                this.consoleWriter.WriteLine(commandResult);
            }
            catch (Exception e)
            {
                this.consoleWriter.WriteLine(e.Message);
            }
        }
    }
}
