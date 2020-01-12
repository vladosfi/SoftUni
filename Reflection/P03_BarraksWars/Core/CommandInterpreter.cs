namespace P03_BarraksWars.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using _03BarracksFactory.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
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
