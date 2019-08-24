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
            //TODO: implement for Problem 3
            Assembly assembly = typeof(AppEntryPoint).Assembly;

            Type currnetUnitType = assembly.GetTypes().FirstOrDefault(x => x.Name == unitType);

            if (currnetUnitType == null)
            {
                throw new ArgumentException("Not valid Unit");
            }

            return (IUnit)Activator.CreateInstance(currnetUnitType);
        }
    }
}
