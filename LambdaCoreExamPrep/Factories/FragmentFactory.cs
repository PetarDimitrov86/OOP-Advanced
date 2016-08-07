namespace LambdaCore_Skeleton.Factories
{
    using Models.Fragments;

    public class FragmentFactory
    {
        public CoolingFragment CreateCoolingFragment(string[] data)
        {
            return new CoolingFragment(data[2], int.Parse(data[3]));
        }

        public NuclearFragment CreateNuclearFragment(string[] data)
        {
            return new NuclearFragment(data[2], int.Parse(data[3]));
        }
    }
}