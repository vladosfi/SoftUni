namespace MXGP
{
    using MXGP.Core;
    using MXGP.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new ChampionshipController(), new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}
