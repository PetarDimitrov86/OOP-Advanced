namespace LambdaCore_Solution.Commands
{
    using System;

    using LambdaCore_Solution.Enums;
    using LambdaCore_Solution.Exceptions;
    using LambdaCore_Solution.Interfaces;
    using LambdaCore_Solution.Utilities;

    public class AttachFragmentCommand : BaseCommand
    {
        private FragmentType lateInstantiationFragmentType;

        private string lateInstantiationFragmentName;

        private int lateInstantiationFragmentPressureAffection;

        public AttachFragmentCommand(
            IPowerPlant powerPlant,
            FragmentType lateInstantiationFragmentType,
            string lateInstantiationFragmentName,
            int lateInstantiationFragmentPressureAffection)
            : base(powerPlant)
        {
            this.LateInstantiationFragmentType = lateInstantiationFragmentType;
            this.LateInstantiationFragmentName = lateInstantiationFragmentName;
            this.LateInstantiationFragmentPressureAffection = lateInstantiationFragmentPressureAffection;
        }

        public FragmentType LateInstantiationFragmentType
        {
            get
            {
                return this.lateInstantiationFragmentType;
            }

            protected set
            {
                this.lateInstantiationFragmentType = value;
            }
        }

        public string LateInstantiationFragmentName
        {
            get
            {
                return this.lateInstantiationFragmentName;
            }

            protected set
            {
                this.lateInstantiationFragmentName = value;
            }
        }

        public int LateInstantiationFragmentPressureAffection
        {
            get
            {
                return this.lateInstantiationFragmentPressureAffection;
            }

            protected set
            {
                this.lateInstantiationFragmentPressureAffection = value;
            }
        }

        public override string Execute()
        {
            string result;

            try
            {
                string path = Constants.FragmentTypeFullName + this.LateInstantiationFragmentType
                              + Constants.FragmentModelNameSuffix;

                IFragment newFragment =
                    (IFragment)Activator.CreateInstance(
                        Type.GetType(path),
                    this.LateInstantiationFragmentName,
                    this.LateInstantiationFragmentPressureAffection);

                this.PowerPlant.AttachFragment(newFragment);

                result = string.Format(
                    Messages.SuccessFragmentAttachMessage,
                    newFragment.Name,
                    this.PowerPlant.CurrentlySelectedCore.Name);
            }
            catch (NoSelectedCoreException)
            {
                result = string.Format(
                    Messages.FailureFragmentAttachMessage,
                    this.LateInstantiationFragmentName);
            }
            catch (Exception)
            {
                result = string.Format(
                    Messages.FailureFragmentAttachMessage,
                    this.LateInstantiationFragmentName);
            }

            return result;
        }
    }
}
