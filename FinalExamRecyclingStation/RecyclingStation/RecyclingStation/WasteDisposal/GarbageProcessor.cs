namespace RecyclingStation.WasteDisposal
{
    using System;
    using Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public GarbageProcessor() : this(new StrategyHolder()) 
        {
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();
            IGarbageDisposalStrategy currentStrategy;
            try
            {
                currentStrategy = this.StrategyHolder.GetDisposalStrategies[type];
                return currentStrategy.ProcessGarbage(garbage);
            }
            catch (Exception)
            {
                throw new ArgumentException(
          "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }
        }
    }
}
