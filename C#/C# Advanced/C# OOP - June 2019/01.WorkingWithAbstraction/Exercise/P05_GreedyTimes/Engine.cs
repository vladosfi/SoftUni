namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private string[] safeContent;
        private Dictionary<string, Dictionary<string, long>> bag;

        public Engine()
        {
            bag = new Dictionary<string, Dictionary<string, long>>();
        }

        public void Start()
        {
            long capacity = long.Parse(Console.ReadLine());
            safeContent = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            long gold = 0;
            long gem = 0;
            long cash = 0;

            for (int i = 0; i < safeContent.Length; i += 2)
            {
                string itemName = safeContent[i];
                long count = long.Parse(safeContent[i + 1]);

                string itemType = GetItemType(itemName);

                if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + count ||
                    itemType == "")
                {
                    continue;
                }

                if (!ValidateConditions(itemType, count))
                {
                    continue;
                }

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, long>();
                }

                if (!bag[itemType].ContainsKey(itemName))
                {
                    bag[itemType][itemName] = 0;
                }

                bag[itemType][itemName] += count;

                if (itemType == "Gold")
                {
                    gold += count;
                }
                else if (itemType == "Gem")
                {
                    gem += count;
                }
                else if (itemType == "Cash")
                {
                    cash += count;
                }
            }

            PrintCollectedItems();
        }


        private bool ValidateConditions(string itemType, long count)
        {
            bool isValid = true;

            switch (itemType)
            {
                case "Gem":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (count > bag["Gold"].Values.Sum())
                            {
                                isValid = false;
                            }
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + count > bag["Gold"].Values.Sum())
                    {
                        isValid = false;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (count > bag["Gem"].Values.Sum())
                            {
                                isValid = false;
                            }
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + count > bag["Gem"].Values.Sum())
                    {
                        isValid = false;
                    }
                    break;
            }

            return isValid;
        }

        private void PrintCollectedItems()
        {
            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");

                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private string GetItemType(string name)
        {
            string itemType = string.Empty;

            if (name.Length == 3)
            {
                itemType = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                itemType = "Gold";
            }

            return itemType;
        }
    }
}
