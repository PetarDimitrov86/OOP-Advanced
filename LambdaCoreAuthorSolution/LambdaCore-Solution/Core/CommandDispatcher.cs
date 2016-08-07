namespace LambdaCore_Solution.Core
{
    using System;

    using LambdaCore_Solution.Commands;
    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Interfaces;

    public class CommandDispatcher : ICommandDispatcher
    {
        private IPowerPlant nuclearPowerPlant;

        public CommandDispatcher()
        {
            this.NuclearPowerPlant = new NuclearPowerPlant();
        }

        public IPowerPlant NuclearPowerPlant
        {
            get
            {
                return this.nuclearPowerPlant;
            }

            private set
            {
                this.nuclearPowerPlant = value;
            }
        }

        public ICommand DispatchCommand(string commandName, string[] arguments)
        {
            ICommand command = null;

            switch (commandName)
            {
                case "CreateCore":
                    command = new CreateCoreCommand(this.NuclearPowerPlant, (CoreType)Enum.Parse(typeof(CoreType), arguments[0]), this.NuclearPowerPlant.NextCoreName, int.Parse(arguments[1]));
                    break;
                case "RemoveCore":
                    command = new RemoveCoreCommand(this.NuclearPowerPlant, arguments[0]);
                    break;
                case "SelectCore":
                    command = new SelectCommand(this.NuclearPowerPlant, arguments[0]);
                    break;
                case "AttachFragment":
                    command = new AttachFragmentCommand(this.NuclearPowerPlant, (FragmentType)Enum.Parse(typeof(FragmentType), arguments[0]), arguments[1], int.Parse(arguments[2]));
                    break;
                case "DetachFragment":
                    command = new DetachFragmentCommand(this.NuclearPowerPlant);
                    break;
                case "Status":
                    command = new StatusCommand(this.NuclearPowerPlant);
                    break;
                case "System Shutdown":
                    break;
            }

            return command;
        }
    }
}
