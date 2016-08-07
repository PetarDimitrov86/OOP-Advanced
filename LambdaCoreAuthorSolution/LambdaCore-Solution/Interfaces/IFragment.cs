namespace LambdaCore_Solution.Interfaces
{
    using LambdaCore_Solution.Enums;

    public interface IFragment
    {
        string Name { get; }

        FragmentType Type { get; }

        int PressureAffection { get; }
    }
}
