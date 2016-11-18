using System;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Garbage_Disposal_Strategies
{
    [RecyclableDisposable]
    public class RecyclableStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            if (garbage == null)
            {
                throw new NullReferenceException("Cannot give a null garbage");
            }
            this.EnergyProduced = 0;
            this.CapitalProduced = 0;
            this.EnergyProduced -= 0.5 * garbage.Weight*garbage.VolumePerKg;
            this.CapitalProduced += 400*garbage.Weight;
            return new ProcessingData(EnergyProduced, CapitalProduced);
        }
    }
}