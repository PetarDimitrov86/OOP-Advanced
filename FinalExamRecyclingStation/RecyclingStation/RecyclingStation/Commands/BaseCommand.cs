using RecyclingStation.Interfaces;

namespace RecyclingStation.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private IRecyclingStation recyclingStation;

        protected BaseCommand(IRecyclingStation recyclingStation)
        {
            this.RecyclingStation = recyclingStation;
        }

        protected IRecyclingStation RecyclingStation { get; }

        public abstract string Execute();
    }
}
