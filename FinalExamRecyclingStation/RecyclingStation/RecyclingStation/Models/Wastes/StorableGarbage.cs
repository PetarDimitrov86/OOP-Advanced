using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Models.Wastes
{
    [StorableDisposable]
    public class StorableGarbage : Waste
    {
        public StorableGarbage(string name, double volumePerKg, double weight) : base(name, volumePerKg, weight)
        {
        }
    }
}