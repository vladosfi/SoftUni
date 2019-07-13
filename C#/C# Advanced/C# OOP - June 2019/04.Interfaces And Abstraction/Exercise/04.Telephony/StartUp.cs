using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            CallPhoneNumbers(phoneNumbers, smartphone);
            BrowseSites(sites, smartphone);
        }

        private static void BrowseSites(string[] sites, Smartphone smartphone)
        {
            foreach (var site in sites)
            {
                Console.WriteLine(smartphone.Browsing(site));
            }
        }

        private static void CallPhoneNumbers(string[] phoneNumbers, Smartphone smartphone)
        {
            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(smartphone.Calling(number));
            }
        }
    }
}
