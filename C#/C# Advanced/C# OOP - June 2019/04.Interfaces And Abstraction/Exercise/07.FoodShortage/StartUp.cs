namespace FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            var dataReader = new ConsoleDataReader();
            var dataWriter = new ConsoleDataWriter();

            Engine engine = new Engine(dataReader, dataWriter);
            engine.Run();
        }
    }
}
