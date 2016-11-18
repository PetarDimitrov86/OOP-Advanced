using System;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Garbage_Disposal_Strategies
{
    [BurnableDisposable]
    public class BurnableStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            if (garbage == null)
            {
                throw new NullReferenceException("Cannot give a null garbage");
            }
            this.EnergyProduced = 0;
            this.CapitalProduced = 0;
            this.EnergyProduced += 0.8*garbage.Weight*garbage.VolumePerKg;
            return new ProcessingData(this.EnergyProduced, this.CapitalProduced);
        }
    }
}