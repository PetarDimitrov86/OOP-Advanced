using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models
{
    public abstract class Waste : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;

        protected Waste(string name, double volumePerKg, double weight)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name { get; protected set; }

        public double VolumePerKg { get; protected set; }

        public double Weight { get; protected set; }
    }
}
