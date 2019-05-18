using System;

namespace CarEngineAndTires
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new Tire[4]
            {
                new Tire(1,2.5),
                new Tire(1,1.5),
                new Tire(1,1.9),
                new Tire(1,2.0)
            };

            var engine = new Engine(560, 6300);

            var car = new Car("Lamborgini", "Urus", 2010, 250, 9, engine, tires);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
