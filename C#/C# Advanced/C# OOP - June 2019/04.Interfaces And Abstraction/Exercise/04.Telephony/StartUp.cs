using System;

namespace _04.Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            ICall smartphone = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(smartphone.Calling(number));
            }

            foreach (var site in sites)
            {
                Console.WriteLine(smartphone.Browsing(site));
            }
        }
    }
}
