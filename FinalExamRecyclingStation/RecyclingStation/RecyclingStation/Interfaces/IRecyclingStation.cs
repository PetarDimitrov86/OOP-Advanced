using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Interfaces
{
    public interface IRecyclingStation
    {
        double Energy { get; set; }
        double Capital { get; set; }
        StrategyHolder StrategyHolder { get; }
        GarbageProcessor GarbageProcessor { get; }
        void ProcessThatGarbage(IWaste waste);
    }
}