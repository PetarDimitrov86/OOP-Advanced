using LambdaCore_Skeleton.Enums;

namespace LambdaCore_Skeleton.Models.Fragments
{
    public class CoolingFragment : BaseFragment
    {
        public CoolingFragment(string name, int pressureAffection)
            : base(name, pressureAffection * 3)
        {
            this.Type = FragmentType.Cooling;
        }
    }
}