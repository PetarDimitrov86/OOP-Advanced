namespace LambdaCore_Solution.Models.Fragments
{
    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Utilities;

    public class NuclearFragment : BaseFragment
    {
        public NuclearFragment(string name, int pressureAffection)
            : base(name, pressureAffection)
        {
            this.Type = FragmentType.Nuclear;
        }

        public override int PressureAffection
        {
            protected set
            {
                base.PressureAffection = value * Constants.NuclearFragmentPressureAffectionIncreaseFactor;
            }
        }
    }
}
