using System;
using ClassBoxData.Models;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                var box = new Box(length, width, height);

                Console.WriteLine(box);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
