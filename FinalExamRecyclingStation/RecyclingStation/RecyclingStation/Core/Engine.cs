using System;
using RecyclingStation.Interfaces;
using RecyclingStation.IO;

namespace RecyclingStation.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IInterpreter commandInterpreter;
        private bool isRunning;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string input = this.reader.ReadLine();
                this.ProcessInput(input);
            }
        }

        private void ProcessInput(string input)
        {
            string[] inputSplit = input.Split();
            string commandType = inputSplit[0];

            if (commandType.Equals("TimeToRecycle"))
            {
                this.isRunning = false;
                return;
            }

            string[] commandInfo = null;

            if (inputSplit.Length > 1)
            {
                commandInfo = inputSplit[1].Split( new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            }           
            ICommand command = this.commandInterpreter.InterpretCommand(commandType, commandInfo);
            if (command == null)
            {
                throw new NullReferenceException("Invalid Command!");
            }

            string commandResult = command.Execute();
            this.writer.WriteLine(commandResult);
        }
    }
}