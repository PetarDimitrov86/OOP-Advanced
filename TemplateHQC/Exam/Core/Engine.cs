using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Interfaces;
using Exam.IO;
using Exam.Utilities;

namespace Exam.Core
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

            if (commandType.Equals("SOME COMMAND NAME"))
            {
                this.isRunning = false;
                return;
            }

            string[] commandInfo = null;

            if (inputSplit.Length > 1)
            {
                commandInfo = inputSplit[1].Split( new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            try
            {
                ICommand command = this.commandInterpreter.InterpretCommand(commandType, commandInfo);
                if (command == null)
                {
                    throw new NullReferenceException("Invalid Command!");
                }

                string commandResult = command.Execute();
                this.writer.WriteLine(commandResult);
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}