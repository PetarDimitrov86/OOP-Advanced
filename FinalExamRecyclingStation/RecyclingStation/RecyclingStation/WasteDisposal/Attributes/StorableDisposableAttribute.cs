using System;

namespace RecyclingStation.WasteDisposal.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StorableDisposableAttribute : DisposableAttribute
    {
    }
}
