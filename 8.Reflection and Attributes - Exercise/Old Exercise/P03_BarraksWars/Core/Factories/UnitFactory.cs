namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Reflection;
    using Contracts;
    using System.Linq;
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assemblyInfo = Assembly.GetCallingAssembly();
            Type type = assemblyInfo.GetTypes().Where(x => x.Name == unitType).FirstOrDefault();
            object typeInstance = Activator.CreateInstance(type) as IUnit;
            
            return typeInstance as IUnit;
        }
    }
}
