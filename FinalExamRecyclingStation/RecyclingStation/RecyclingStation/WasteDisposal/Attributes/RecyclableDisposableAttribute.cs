using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingStation.WasteDisposal.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RecyclableDisposableAttribute : DisposableAttribute
    {
    }
}
