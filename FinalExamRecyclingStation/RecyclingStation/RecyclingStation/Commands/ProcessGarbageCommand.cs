using System;
using RecyclingStation.Interfaces;
using RecyclingStation.Models;
using RecyclingStation.Models.Wastes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Commands
{
    public class ProcessGarbageCommand : BaseCommand
    {
        private string wasteName;
        private double wasteWeight;
        private double volumePerKg;
        private string type;

        public ProcessGarbageCommand(IRecyclingStation recyclingStation, string name, double weight, double volumePerKg, string type) : base(recyclingStation)
        {
            this.wasteName = name;
            this.wasteWeight = weight;
            this.volumePerKg = volumePerKg;
            this.type = type;
        }

        public override string Execute()
        {
            IProcessingData processingData = null; 
            if (this.type == "Recyclable")
            {
                processingData = this.RecyclingStation.GarbageProcessor.ProcessWaste(new RecyclableGarbage(this.wasteName,
                    this.volumePerKg, this.wasteWeight));
            }
            else if (this.type == "Burnable")
            {
                processingData = this.RecyclingStation.GarbageProcessor.ProcessWaste(new BurnableGarbage(this.wasteName, this.volumePerKg,
                    this.wasteWeight));
            }
            else if (this.type == "Storable")
            {
                processingData =  this.RecyclingStation.GarbageProcessor.ProcessWaste(new StorableGarbage(this.wasteName, this.volumePerKg,
                    this.wasteWeight));
            }   
            this.RecyclingStation.Capital += processingData.CapitalBalance;
            this.RecyclingStation.Energy += processingData.EnergyBalance;

            return $"{this.wasteWeight:f2} kg of {this.wasteName} successfully processed!";
        }
    }
}
