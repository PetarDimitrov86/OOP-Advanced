namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enums;

    public class NuclearFragment : BaseFragment
    {
        public NuclearFragment(string name, int pressureAffection)
            : base(name, pressureAffection * 2)
        {
            this.Type = FragmentType.Nuclear;
        }
    }
}