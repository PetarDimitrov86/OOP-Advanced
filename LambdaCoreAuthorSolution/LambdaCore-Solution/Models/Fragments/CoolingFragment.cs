namespace LambdaCore_Solution.Models.Fragments
{
    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Utilities;

    public class CoolingFragment : BaseFragment
    {
        public CoolingFragment(string name, int pressureAffection)
            : base(name, pressureAffection)
        {
            this.Type = FragmentType.Cooling;
        }

        public override int PressureAffection
        {
            protected set
            {
                base.PressureAffection = value * Constants.CoolingFragmentPressureAffectionIncreaseFactor;
            }
        }
    }
}
