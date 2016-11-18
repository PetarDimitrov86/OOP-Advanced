using RecyclingStation.Interfaces;
using RecyclingStation.Models.Garbage_Disposal_Strategies;
using RecyclingStation.Models.Wastes;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Core
{
    public class RecyclingStation : IRecyclingStation
    {
        private double energy;
        private double capital;
        private StrategyHolder strategyHolder;
        private GarbageProcessor garbageProcessor;

        public RecyclingStation()
        {
            this.Energy = 0;
            this.Capital = 0;
            this.StrategyHolder = this.GetAllStrategies();
            this.GarbageProcessor = new GarbageProcessor(this.StrategyHolder);
        }

        public double Energy { get; set; }

        public double Capital { get; set; }

        public StrategyHolder StrategyHolder { get; }

        public GarbageProcessor GarbageProcessor { get; }

        private StrategyHolder GetAllStrategies()
        {
            StrategyHolder stratHolder = new StrategyHolder();
            stratHolder.AddStrategy(typeof(RecyclableGarbage), new RecyclableStrategy());
            stratHolder.AddStrategy(typeof(BurnableGarbage), new BurnableStrategy());
            stratHolder.AddStrategy(typeof(StorableGarbage), new StorableStrategy());
            return stratHolder;
        }

        public void ProcessThatGarbage(IWaste waste)
        {
            this.GarbageProcessor.ProcessWaste(waste);
        }
    }
}
