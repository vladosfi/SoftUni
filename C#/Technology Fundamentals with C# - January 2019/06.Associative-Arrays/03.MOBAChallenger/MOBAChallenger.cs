using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class MOBAChallenger
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                string[] tokens;

                if (input == "Season end")
                {
                    break;
                }
                else if (input.Contains(" -> "))
                {
                    tokens = input.Split(" -> ");
                    string player = tokens[0];
                    string position = tokens[1];
                    int skill = int.Parse(tokens[2]);

                    if (!players.ContainsKey(player))
                    {
                        players.Add(player, new Dictionary<string, int>());
                    }

                    if (!players[player].ContainsKey(position))
                    {
                        players[player].Add(position, 0);
                    }


                    if (players[player][position] < skill)
                    {
                        players[player][position] = skill;
                    }
                }
                else if (input.Contains(" vs "))
                {
                    tokens = input.Split(" vs ");
                    string playerOne = tokens[0];
                    string playerTwo = tokens[1];

                    if (players.ContainsKey(playerOne) && players.ContainsKey(playerTwo))
                    {
                        if (LastOneEqualPosition(players, playerOne, playerTwo))
                        {
                            string position = GetCommonPosition(players, playerOne, playerTwo);
                            if (position != null)
                            {
                                if (players[playerOne][position] > players[playerTwo][position])
                                {
                                    players.Remove(playerTwo);
                                }
                                else if (players[playerOne][position] < players[playerTwo][position])
                                {
                                    players.Remove(playerOne);
                                }
                            }
                        }
                        
                    }
                }   
            }

            foreach (var kvp in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");

                foreach (var innerKvp in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {innerKvp.Key} <::> {innerKvp.Value}");
                }
            }
        }
        private static string GetCommonPosition(Dictionary<string, Dictionary<string, int>> players, string playerOne, string playerTwo)
        {
            foreach (var kvp in players[playerOne])
            {
                if (players[playerTwo].ContainsKey(kvp.Key))
                {
                    return kvp.Key;
                }
            }

            return null;
        }

        private static bool LastOneEqualPosition(Dictionary<string, Dictionary<string, int>> players, string playerOne, string playerTwo)
        {
            foreach (var kvp in players[playerOne])
            {
                if (players[playerTwo].ContainsKey(kvp.Key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
