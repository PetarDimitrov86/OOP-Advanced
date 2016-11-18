using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Models.Wastes
{
    [BurnableDisposable]
    public class BurnableGarbage : Waste
    {
        public BurnableGarbage(string name, double volumePerKg, double weight) : base(name, volumePerKg, weight)
        {

        }
    }
}