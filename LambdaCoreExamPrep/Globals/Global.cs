using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Globals
{
    using Models.Cores;

    public static class Global
    {
        public static char CurrentCoreLetter;
        public static ICore SelectedCore;

        static Global()
        {
            CurrentCoreLetter = 'A';
            SelectedCore = null;
        }
    }
}