namespace LambdaCore_Solution.Interfaces
{
    public interface ICore
    {
        string Name { get; }

        int Durability { get; }

        int FragmentsCount { get; }

        long CurrentPressure { get; }

        IFragment AttachFragment(IFragment fragment);

        IFragment DetachFragment();

        IFragment PeekFragment();
    }
}
