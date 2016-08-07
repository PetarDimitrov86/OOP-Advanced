namespace LambdaCore_Skeleton.Interfaces
{
    public interface ICommand
    {
        string Message { get; }
        void Execute();
    }
}
