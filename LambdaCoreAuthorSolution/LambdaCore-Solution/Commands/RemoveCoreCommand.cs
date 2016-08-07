namespace LambdaCore_Solution.Commands
{
    using System;

    using LambdaCore_Solution.Exceptions;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Utilities;

    public class RemoveCoreCommand : BaseCommand
    {
        private string lateRemovingCoreName;

        public RemoveCoreCommand(IPowerPlant powerPlant, string lateRemovingCoreName)
            : base(powerPlant)
        {
            this.LateRemovingCoreName = lateRemovingCoreName;
        }

        protected string LateRemovingCoreName
        {
            get
            {
                return this.lateRemovingCoreName;
            }

            set
            {
                this.lateRemovingCoreName = value;
            }
        }

        public override string Execute()
        {
            string result;

            try
            {
                ICore detachedCore = this.PowerPlant.DetachCore(this.LateRemovingCoreName);
                result = string.Format(Messages.SuccessCoreRemoveMessage, detachedCore.Name);
            }
            catch (UnexistentCoreException)
            {
                result = string.Format(Messages.FailureCoreRemoveMessage, this.LateRemovingCoreName);
            }
            catch (Exception)
            {
                result = string.Format(Messages.FailureCoreRemoveMessage, this.LateRemovingCoreName);
            }

            return result;
        }
    }
}
