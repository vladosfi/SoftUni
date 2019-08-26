using Logger2.Core;
using Logger2.Core.Contracts;

namespace Logger2
{
    class Startup
    {
        static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
