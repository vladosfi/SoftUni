using System;

namespace SquareRoot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(GetSquareRoot(number));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static double GetSquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"The number should be positive!");
            }

            return Math.Sqrt(number);
        }
    }
}
