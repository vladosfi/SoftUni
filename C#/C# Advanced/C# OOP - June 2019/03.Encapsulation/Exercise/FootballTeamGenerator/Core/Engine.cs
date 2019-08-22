using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Model;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            
            while (input != "END")
            {
                try
                {
                    ExecuteCommand(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }

        private void ExecuteCommand(string input)
        {
            string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            string teamName = tokens[1];

            if (command == "Team")
            {
                teams.Add(new Team(teamName));
            }
            else if (command == "Add")
            {
                string playerName = tokens[2];
                int endurance = int.Parse(tokens[3]);
                int sprint = int.Parse(tokens[4]);
                int dribble = int.Parse(tokens[5]);
                int passing = int.Parse(tokens[6]);
                int shooting = int.Parse(tokens[7]);

                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new ArgumentException($"Team {tokens[1]} does not exist.");
                }
                else
                {
                    team.AddPlayer(new Player(
                        playerName,
                        endurance,
                        sprint,
                        dribble,
                        passing,
                        shooting));
                }
            }
            else if (command == "Remove")
            {
                string playerName = tokens[2];

                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new ArgumentException($"Team {teamName} does not exist.");
                }
                else
                {
                    team.RemovePlayer(playerName);
                }
            }
            else if (command == "Rating")
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    throw new ArgumentException($"Team {teamName} does not exist.");
                }
                else
                {
                    Console.WriteLine($"{teamName} - {team.Rating:f0}");
                }
            }
        }
    }
}
