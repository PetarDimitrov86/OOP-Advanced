namespace _03BarracksFactory.Core
{
    using System.Linq;
    using System.Reflection;
    using Commands;
    using System;
    using Contracts;
    using Attributes;
    using Factories;
    using Data;

    public class CommandManager : ICommandInterpreter
    {
        [Inject]
        private IRepository repository = new UnitRepository();
        [Inject]
        private IUnitFactory factory = new UnitFactory();

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type typeOfCommand =
                Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(x => x.Name.ToLower() == commandName + "command");
            Command command = (Command)Activator.CreateInstance(typeOfCommand, new object[] { data });
            InjectDependencies(command);
            return command;
        }

        private void InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeof(CommandManager)
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));
                if (fieldAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                    {
                        field.SetValue(command,
                            fieldsOfInterpreter.First(x => x.FieldType == field.FieldType)
                            .GetValue(this));
                    }
                }
            }
        }
    }
}
