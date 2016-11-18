using RecyclingStation.Interfaces;

namespace RecyclingStation.Commands
{
    public class StatusCommand : BaseCommand
    {
        public StatusCommand(IRecyclingStation recyclingStation) : base(recyclingStation)
        {
        }

        public override string Execute()
        {
            return $"Energy: {this.RecyclingStation.Energy:f2} Capital: {this.RecyclingStation.Capital:f2}";
        }
    }
}