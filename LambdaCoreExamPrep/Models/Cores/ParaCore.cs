namespace LambdaCore_Skeleton.Models.Cores
{
    using Enums;

    public class ParaCore : Core
    {
        public ParaCore(CoreType type, int durability) : base(type, durability / 3)
        {
            this.Type = CoreType.Para;
        }
    }
}