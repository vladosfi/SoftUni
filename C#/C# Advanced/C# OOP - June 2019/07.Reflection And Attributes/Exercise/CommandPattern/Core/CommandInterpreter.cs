using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string inpitLine)
        {
            string[] cmdTokens = inpitLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commandName = cmdTokens[0] + COMMAND_POSTFIX;

            string[] commandArgs = cmdTokens
                .Skip(1)
                .ToArray();

            //Assembly assembly = Assembly.GetExecutingAssembly();
			
			
			

            Assembly assembly = Assembly
                .GetCallingAssembly();


            Type[] types = assembly
                .GetTypes();

            Type typeToCreate = types
                .FirstOrDefault(t => t.Name == commandName);

            if (typeToCreate == null)
            {
                return null;
            }

            Object instance = (ICommand)Activator
                .CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
