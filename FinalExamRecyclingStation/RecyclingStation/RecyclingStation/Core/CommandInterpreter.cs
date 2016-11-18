using RecyclingStation.Commands;
using RecyclingStation.Interfaces;

namespace RecyclingStation.Core
{
    public class CommandInterpreter : IInterpreter
    {
        private RecyclingStation recyclingStation;

        public CommandInterpreter()
        {
            this.RecyclingStation = new RecyclingStation();
        }

        public RecyclingStation RecyclingStation { get; private set; }

        public ICommand InterpretCommand(string commandName, string[] arguments)
        {
            ICommand command = null;

            switch (commandName)
            {
                case "ProcessGarbage":
                    return new ProcessGarbageCommand(RecyclingStation, arguments[0], 
                        double.Parse(arguments[1]), double.Parse(arguments[2]), arguments[3]);
                    break;
                case "Status":
                    return new StatusCommand(this.RecyclingStation);
                    break;
            }
            return command;
        }
    }
}