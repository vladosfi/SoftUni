using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.QuestsJournal
{
    class QuestsJournal
    {
        static void Main()
        {
            List<string> journal = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" - ");
                
                if (input[0] == "Retire!")
                {
                    break;
                }

                string command = input[0];
                string quest = input[1];

                if (command == "Start" && !journal.Contains(quest))
                {
                    journal.Add(quest);
                }
                else if (command == "Complete" && journal.Contains(quest))
                {
                    journal.Remove(quest);
                }
                else if (command == "Side Quest")
                {
                    string[] tokens = quest.Split(":");
                    quest = tokens[0];
                    string sideQuest = tokens[1];

                    if (journal.Contains(quest) && !journal.Contains(sideQuest))
                    {
                        
                        int indexOfQuest = journal.IndexOf(quest);
                        journal.Insert(indexOfQuest+1, sideQuest);
                    }
                }
                else if (command == "Renew" && journal.Contains(quest))
                {
                    journal.Remove(quest);
                    journal.Insert(journal.Count, quest);
                }
            }

            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
