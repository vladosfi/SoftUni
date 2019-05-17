using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{
    class AdvertisementMessage
    {
        static Random rnd = new Random();

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<string> phrases = new List<string>(){
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            List<string> events = new List<string>(){"Now I feel good.",
                    "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            List<string> authors = new List<string>(){"Diana","Petya","Stella","Elena","Katya","Iva","Annie","Eva"};

            List<string> cities = new List<string>(){ "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Randomize(phrases);
            Randomize(events);
            Randomize(authors);
            Randomize(cities);

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{phrases[i]} {events[i]} {authors[i]} – {cities[i]}.");
            }
        }

        private static void Randomize(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int index = rnd.Next(0, list.Count);
                string curElement = list[i];

                list[i] = list[index];
                list[index] = curElement;
            }
        }
    }
}
