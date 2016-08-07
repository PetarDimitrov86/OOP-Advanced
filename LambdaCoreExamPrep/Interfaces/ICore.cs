namespace LambdaCore_Skeleton.Interfaces
{
    using Enums;
    using Collection;

    public interface ICore
    {
        string Name { get; }
        CoreType Type { get; }
        int Durability { get; set; }
        LStack Fragments { get; }
        string Status();
    }
}