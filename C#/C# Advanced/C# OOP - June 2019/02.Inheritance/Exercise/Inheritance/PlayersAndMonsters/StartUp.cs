namespace PlayersAndMonsters
{
    using PlayersAndMonsters.Elfs;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MuseElf museElf = new MuseElf("ElfName",199);
            System.Console.WriteLine(museElf);
        }
    }
}