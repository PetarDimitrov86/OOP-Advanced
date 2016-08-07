namespace LambdaCore_Solution.Interfaces
{
    public interface IPowerPlant
    {
        int CountOfCores { get; }

        int CountOfFragments { get; }

        string NextCoreName { get; }

        ICore CurrentlySelectedCore { get; }

        bool HasSelectedCore();

        void SelectCore(string coreName);

        void AttachCore(ICore core);

        ICore DetachCore(string coreName);

        ICore GetCore(string coreName);

        bool ContainsCore(string coreName);

        void AttachFragment(IFragment fragment);

        IFragment DetachFragment();
    }
}
