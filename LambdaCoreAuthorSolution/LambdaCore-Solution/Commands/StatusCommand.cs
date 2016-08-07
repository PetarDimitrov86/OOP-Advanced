namespace LambdaCore_Solution.Commands
{
    using LambdaCore_Solution.Interfaces;

    public class StatusCommand : BaseCommand
    {
        public StatusCommand(IPowerPlant powerPlant)
            : base(powerPlant)
        {
        }

        public override string Execute()
        {
            string result = this.PowerPlant.ToString();
            return result;
        }
    }
}
