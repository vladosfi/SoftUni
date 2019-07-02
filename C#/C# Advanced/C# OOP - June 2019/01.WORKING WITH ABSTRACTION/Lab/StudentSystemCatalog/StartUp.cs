namespace StudentSystemCatalog
{
    using System;
    using System.Threading;
    using StudentSystemCatalog.Commands;
    using StudentSystemCatalog.Students;

    public class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var commandParcer = new CommandParcer();
            var studentSystem = new StudentSystem();

            var engine = new Engine(
                commandParcer, 
                studentSystem,
                Console.ReadLine,
                Console.WriteLine
                );

            engine.Run();

        }
    }
}
