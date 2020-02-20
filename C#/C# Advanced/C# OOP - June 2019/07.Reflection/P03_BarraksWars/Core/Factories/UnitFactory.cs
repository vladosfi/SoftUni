namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type currentUnitType = assembly.GetTypes().FirstOrDefault(t=>t.Name == unitType);

            if (currentUnitType == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            return (IUnit)Activator.CreateInstance(currentUnitType);
        }
    }
}
