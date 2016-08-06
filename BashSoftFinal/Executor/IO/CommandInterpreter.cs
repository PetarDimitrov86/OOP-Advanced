using System;
using System.Linq;
using System.Reflection;
using Executor.Attributes;
using Executor.Contracts;
using Executor.IO.Commands;

namespace Executor.IO
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDownloadManager downloadManager;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository,
            IDownloadManager downloadManager, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = new object[] { input, data };

            Type typeOfCommand =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(type =>type.GetCustomAttributes(typeof(AliasAttribute))
                                .Where(atr => atr.Equals(command))
                                .ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command) Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x=>x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter
                            .First(x=>x.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }
            return exe;
        }
    }
}
