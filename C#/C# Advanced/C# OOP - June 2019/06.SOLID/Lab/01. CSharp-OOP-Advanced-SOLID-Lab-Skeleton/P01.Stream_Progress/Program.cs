using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IResult file = new File("123.txt", 100, 20);
            IResult musik = new Music("pantera", "2018", 100, 24);

            StreamProgressInfo progress = new StreamProgressInfo(file);
            Console.WriteLine(progress.CalculateCurrentPercent());

            progress = new StreamProgressInfo(musik);
            Console.WriteLine(progress.CalculateCurrentPercent());
        }
    }
}
