namespace LambdaCore_Solution.Interfaces
{
    public interface ICommandDispatcher
    {
        IPowerPlant NuclearPowerPlant { get; }

        ICommand DispatchCommand(string commandName, string[] arguments);
    }
}
