namespace LambdaCore_Solution.Commands
{
    using LambdaCore_Solution.Interfaces;

    public abstract class BaseCommand : ICommand
    {
        private IPowerPlant powerPlant;

        protected BaseCommand(IPowerPlant powerPlant)
        {
            this.PowerPlant = powerPlant;
        }

        protected IPowerPlant PowerPlant
        {
            get
            {
                return this.powerPlant;
            }

            set
            {
                this.powerPlant = value;
            }
        }

        public abstract string Execute();
    }
}
