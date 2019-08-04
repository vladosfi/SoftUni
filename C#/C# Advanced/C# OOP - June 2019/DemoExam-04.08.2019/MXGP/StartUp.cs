namespace MXGP
{
    using System;
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //TODO Add IEngine
            Motorcycle varche = new PowerMotorcycle("12214235", 75);
            Console.WriteLine(varche.HorsePower);

            Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }

    }
}
