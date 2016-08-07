namespace LambdaCore_Solution.Commands
{
    using System;

    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Utilities;

    public class CreateCoreCommand : BaseCommand
    {
        private CoreType lateInstantiationCoreType;

        private string lateInstantiationCoreName;

        private int lateInstantiationCoreEnergyOutput;

        public CreateCoreCommand(
            IPowerPlant powerPlant,
            CoreType lateInstantiationCoreType,
            string lateInstantiationCoreName,
            int lateInstantiationCoreEnergyOutput)
            : base(powerPlant)
        {
            this.LateInstantiationCoreType = lateInstantiationCoreType;
            this.LateInstantiationCoreName = lateInstantiationCoreName;
            this.LateInstantiationCoreEnergyOutput = lateInstantiationCoreEnergyOutput;
        }

        protected CoreType LateInstantiationCoreType
        {
            get
            {
                return this.lateInstantiationCoreType;
            }

            set
            {
                this.lateInstantiationCoreType = value;
            }
        }

        protected string LateInstantiationCoreName
        {
            get
            {
                return this.lateInstantiationCoreName;
            }

            set
            {
                this.lateInstantiationCoreName = value;
            }
        }

        protected int LateInstantiationCoreEnergyOutput
        {
            get
            {
                return this.lateInstantiationCoreEnergyOutput;
            }

            set
            {
                this.lateInstantiationCoreEnergyOutput = value;
            }
        }

        public override string Execute()
        {
            string result;

            try
            {
                string path = Constants.CoreTypeFullName + this.LateInstantiationCoreType + Constants.CoreModelNameSuffix;
                ICore newCore =
                    (ICore)
                    Activator.CreateInstance(
                    Type.GetType(path),
                    this.LateInstantiationCoreName, 
                    this.LateInstantiationCoreEnergyOutput);

                this.PowerPlant.AttachCore(newCore);
                result = string.Format(Messages.SuccessCoreCreateMessage, newCore.Name);
            }
            catch (Exception e)
            {
                var b = e;
                result = Messages.FailureCoreCreateMessage;
            }

            return result;
        }
    }
}
