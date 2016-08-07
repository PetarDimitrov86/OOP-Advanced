namespace LambdaCore_Skeleton.Factories
{
    using Enums;

    using Models.Cores;

    public class CoreFactory
    {
        public ParaCore CreateParaCore(string[] data)
        {
            return new ParaCore(CoreType.Para, int.Parse(data[2]));
        }

        public SystemCore CreateSystemCore(string[] data)
        {
            return new SystemCore(CoreType.System, int.Parse(data[2]));
        }
    }
}