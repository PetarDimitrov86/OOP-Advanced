namespace LambdaCore_Skeleton.Models.Cores
{
    using Interfaces;
    using Enums;
    using Globals;
    using Collection;
    using Fragments;

    public abstract class Core : ICore
    {
        private string name;
        private CoreType type;
        private int durability;
        private LStack fragments;

        public Core(CoreType type, int durability)
        {
            this.Type = type;
            this.Durability = durability;
            this.Fragments = new LStack();
            this.Name = Global.CurrentCoreLetter.ToString();
            Global.CurrentCoreLetter++;
        }
        public string Name { get; protected set; }

        public CoreType Type { get; protected set; }

        public virtual int Durability { get; set; }

        public LStack Fragments { get; protected set; }

        public string Status()
        {
            if (this.Fragments.IsEmpty() ||  this.Fragments.Peek() is CoolingFragment)
            {
                return "NORMAL";
            }
            else if (this.Fragments.Peek() is NuclearFragment)
            {
                return "CRITICAL";
            }
            return null;
        }
    }
}