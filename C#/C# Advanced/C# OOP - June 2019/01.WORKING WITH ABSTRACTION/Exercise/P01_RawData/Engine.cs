namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Engine
    {
        private List<Car> cars;
        private readonly Func<string> readInputFromConsole;
        private readonly Action<string> printToConsole;

        public Engine(Func<string> readInputFromConsole, Action<string> printToConsole)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            this.cars = new List<Car>();
            this.readInputFromConsole = readInputFromConsole;
            this.printToConsole = printToConsole;
        }

        public void Run()   
        {
            Read();

            string command = readInputFromConsole();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(flamable);
            }

        }

        public void Read()
        {
            int lines = int.Parse(readInputFromConsole());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = readInputFromConsole().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                Car car = this.CreateCar(parameters);

                cars.Add(car);
            }
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            double firstTirePressure = double.Parse(parameters[5]);
            int firstTireAge = int.Parse(parameters[6]);
            Tire firstTire = new Tire(firstTireAge, firstTirePressure);

            double secondTirePressure = double.Parse(parameters[7]);
            int secondTireAge = int.Parse(parameters[8]);
            Tire secondTire = new Tire(firstTireAge, firstTirePressure);

            double thirdTirePressure = double.Parse(parameters[9]);
            int thirdTireAge = int.Parse(parameters[10]);
            Tire thirdTire = new Tire(firstTireAge, firstTirePressure);

            double fourthTirePressure = double.Parse(parameters[11]);
            int fourthTireAge = int.Parse(parameters[12]);
            Tire fourthTire = new Tire(firstTireAge, firstTirePressure);

            Car car = new Car(model,
                engineSpeed,
                enginePower,
                cargoWeight,
                cargoType,
                firstTire,
                secondTire,
                thirdTire,
                fourthTire);

            return car;
        }
        
        private static void PrintInfo(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
