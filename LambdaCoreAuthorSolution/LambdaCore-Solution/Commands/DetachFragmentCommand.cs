namespace LambdaCore_Solution.Commands
{
    using System;

    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Utilities;

    public class DetachFragmentCommand : BaseCommand
    {
        public DetachFragmentCommand(IPowerPlant powerPlant)
            : base(powerPlant)
        {
        }

        public override string Execute()
        {
            string result;

            try
            {
                IFragment detachedFragment = this.PowerPlant.DetachFragment();
                result = string.Format(Messages.SuccessFragmentDetachMessage, detachedFragment.Name, this.PowerPlant.CurrentlySelectedCore.Name);
            }
            catch (Exception)
            {
                result = Messages.FailureFragmentDetachMessage;
            }

            return result;
        }
    }
}
