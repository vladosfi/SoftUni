namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using System;

    class AppEntryPoint
    {
        static void Main(string[] args)
        //{
        //    Car car = new Car();
        //    Type type = car.GetType();
        //    Type type2 = typeof(Car);
        //    Type type3 = Type.GetType("_03BarracksFactory.Car");


            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();


        }
    }
}
