namespace LambdaCore_Solution.Commands
{
    using LambdaCore_Solution.Exceptions;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Utilities;

    public class SelectCommand : BaseCommand
    {
        private string lateSelectingCoreName;

        public SelectCommand(IPowerPlant powerPlant, string lateSelectingCoreName)
            : base(powerPlant)
        {
            this.LateSelectingCoreName = lateSelectingCoreName;
        }

        protected string LateSelectingCoreName
        {
            get
            {
                return this.lateSelectingCoreName;
            }

            set
            {
                this.lateSelectingCoreName = value;
            }
        }

        public override string Execute()
        {
            string result;

            try
            {
                this.PowerPlant.SelectCore(this.LateSelectingCoreName);
                result = string.Format(Messages.SuccessCoreSelectMessage, this.PowerPlant.CurrentlySelectedCore.Name);
            }
            catch (UnexistentCoreException)
            {
                result = string.Format(Messages.FailureCoreSelectMessage, this.LateSelectingCoreName);
            }

            return result;
        }
    }
}
