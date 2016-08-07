namespace LambdaCore_Skeleton.Interfaces
{
    using Enums;

    public interface IFragment
    {
        string Name { get; }

        FragmentType Type { get; }

        int PressureAffection { get; }
    }
}