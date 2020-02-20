namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            if (type == null)
            {
                throw new ArgumentException("Invalid Command!");
            }

            var instance = Activator.CreateInstance(type, new object[] { data, unitFactory, repository });

            var method = type.GetMethod("Execute");

            try
            {
                string result = method.Invoke(instance, null) as string;
                return result;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

    }
}
