using System;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Garbage_Disposal_Strategies
{
    [StorableDisposable]
    public class StorableStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            if (garbage == null)
            {
                throw new NullReferenceException("Cannot give a null garbage");
            }
            this.EnergyProduced = 0;
            this.CapitalProduced = 0;
            double result1 = 0.13 * garbage.VolumePerKg * garbage.Weight;
            this.EnergyProduced -= result1;
            double result2 = 0.65*garbage.VolumePerKg*garbage.Weight;
            this.CapitalProduced -= result2;
            return new ProcessingData(EnergyProduced, CapitalProduced);
        }
    }
}