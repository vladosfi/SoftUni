using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _05.DragonArmy
{
    class Dragon
    {
        int damage;
        int health;
        int armor;

        public Dragon(int damage, int health, int armor)
        {
            this.damage = damage;
            this.health = health;
            this.armor = armor;
        }

        public int Damage => this.damage;
        public int Health => this.health;
        public int Armor => this.armor;
    }

    class DragonArmy
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());
            var dragons = new Dictionary<string, Dictionary<string, Dragon>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string type = tokens[0];
                string name = tokens[1];
                int damage = tokens[2] == "null" ? 45 : int.Parse(tokens[2]);
                int health = tokens[3] == "null" ? 250 : int.Parse(tokens[3]);
                int armor = tokens[4] == "null" ? 10 : int.Parse(tokens[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new Dictionary<string, Dragon>());
                }

                Dragon dragon = new Dragon(damage, health, armor);

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type].Add(name, new Dragon(0,0,0));
                }

                dragons[type][name] = dragon;
            }


            foreach (var kvp in dragons)
            {
                Console.WriteLine($"{kvp.Key}::(" +
                    $"{kvp.Value.Select(x => x.Value.Damage).Average():F02}/" +
                    $"{kvp.Value.Select(x => x.Value.Health).Average():F02}/" +
                    $"{kvp.Value.Select(x => x.Value.Armor).Average():F02})");


                foreach (var innerKvp in kvp.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"-{innerKvp.Key}" +
                        $" -> damage: {innerKvp.Value.Damage}, " +
                        $"health: {innerKvp.Value.Health}, " +
                        $"armor: {innerKvp.Value.Armor}");
                }
            }
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;

//namespace _05.DragonArmy
//{
//    class DragonArmy
//    {
//        static void Main()
//        {
//            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
//            int n = int.Parse(Console.ReadLine());
//            var dragons = new Dictionary<string, Dictionary<string, List<int>>>();

//            for (int i = 0; i < n; i++)
//            {
//                string[] tokens = Console.ReadLine().Split();
//                string type = tokens[0];
//                string name = tokens[1];
//                int damage = tokens[2] == "null" ? 45 : int.Parse(tokens[2]);
//                int health = tokens[3] == "null" ? 250 : int.Parse(tokens[3]);
//                int armor = tokens[4] == "null" ? 10 : int.Parse(tokens[4]);

//                if (!dragons.ContainsKey(type))
//                {
//                    dragons.Add(type, new Dictionary<string, List<int>>());
//                }

//                if (!dragons[type].ContainsKey(name))
//                {
//                    dragons[type].Add(name, new List<int>());
//                }

//                dragons[type][name].Clear();
//                dragons[type][name].Add(damage);
//                dragons[type][name].Add(health);
//                dragons[type][name].Add(armor);
//            }


//            foreach (var kvp in dragons)
//            {
//                Console.WriteLine($"{kvp.Key}::(" +
//                    $"{kvp.Value.Select(x => x.Value[0]).Average():F02}/" +
//                    $"{kvp.Value.Select(x => x.Value[1]).Average():F02}/" +
//                    $"{kvp.Value.Select(x => x.Value[2]).Average():F02})");

//                foreach (var innerKvp in kvp.Value.OrderBy(x => x.Key))
//                {
//                    Console.WriteLine($"-{innerKvp.Key} -> damage: {innerKvp.Value[0]}, health: {innerKvp.Value[1]}, armor: {innerKvp.Value[2]}");
//                }
//            }
//        }
//    }
//}