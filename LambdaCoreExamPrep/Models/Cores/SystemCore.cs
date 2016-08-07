namespace LambdaCore_Skeleton.Models.Cores
{
    using Enums;

    public class SystemCore : Core
    {
        public SystemCore(CoreType type, int durability) : base(type, durability)
        {
            this.Type = CoreType.System;
        }
    }
}