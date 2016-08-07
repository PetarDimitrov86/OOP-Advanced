namespace LambdaCore_Skeleton
{
    using System;
    using Enums;
    using Commands;
    using System.Collections.Generic;
    using Interfaces;
    public class CommandInterpreter
    {
        public Command InterpredCommand(string input, List<ICore> repository)
        {
            string[] commandSplit = input.Split(new [] {'@', ':'}, StringSplitOptions.RemoveEmptyEntries);
            CommandType commandType = (CommandType) Enum.Parse(typeof(CommandType), commandSplit[0]);

            try
            {
                switch (commandType)
                {
                    case CommandType.CreateCore:
                        return new CreateCoreCommand(commandSplit, repository);
                        break;
                    case CommandType.AttachFragment:
                        return new AttachFragmentCommand(commandSplit, repository);
                        break;
                    case CommandType.DetachFragment:
                        return new DetachFragmentCommand(commandSplit, repository);
                        break;
                    case CommandType.RemoveCore:
                        return new RemoveCoreCommand(commandSplit, repository);
                        break;
                    case CommandType.SelectCore:
                        return new SelectCoreCommand(commandSplit, repository);
                        break;
                    case CommandType.Status:
                        return new StatusCommand(commandSplit, repository);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
