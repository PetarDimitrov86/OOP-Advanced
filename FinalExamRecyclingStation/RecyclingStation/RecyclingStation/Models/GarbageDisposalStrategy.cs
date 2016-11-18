using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models
{
    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public double EnergyProduced { get; protected set; }

        public double CapitalProduced { get; protected set; }

        protected GarbageDisposalStrategy()
        {
            this.EnergyProduced = 0;
            this.CapitalProduced = 0;
        }

        public abstract IProcessingData ProcessGarbage(IWaste garbage);
    }
}
