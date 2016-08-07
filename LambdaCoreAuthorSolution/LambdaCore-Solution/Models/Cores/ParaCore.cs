namespace LambdaCore_Solution.Models.Cores
{
    using LambdaCore_Solution.Utilities;

    public class ParaCore : BaseCore
    {
        public ParaCore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int Durability
        {
            protected set
            {
                base.Durability = value / Constants.ParaCoreDurabilityDecreaseFactor;
            }
        }
    }
}
