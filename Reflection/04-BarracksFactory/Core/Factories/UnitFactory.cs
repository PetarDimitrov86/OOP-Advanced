using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type T = Assembly.GetExecutingAssembly().DefinedTypes.First(t => t.Name == unitType);
            IUnit unit = Activator.CreateInstance(T) as IUnit;
            return unit;
        }
    }
}
