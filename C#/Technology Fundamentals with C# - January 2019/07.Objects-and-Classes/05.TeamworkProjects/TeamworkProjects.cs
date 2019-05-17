using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Team
    {
        string teamName;
        string creator;
        List<string> members = new List<string>();

        public Team(string creator, string teamName)
        {
            this.teamName = teamName;
            this.creator = creator;
        }

        public string TeamName => this.teamName;
        public string Creator => this.creator;
        public List<string> Members => this.members;

    }

    class TeamworkProjects
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();
            int count = int.Parse(Console.ReadLine());
            string[] input;

            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine().Split("-");
                string creator = input[0];
                string teamName = input[1];

                if (teams.Any(t=>t.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(c=>c.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team newTeam = new Team(input[0], input[1]);
                    teams.Add(newTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            while (true)
            {
                input = Console.ReadLine().Split("->");

                if (input[0] == "end of assignment")
                {
                    break;
                }

                string member = input[0];
                string teamName = input[1];

                if (!teams.Any(t=>t.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(x => x.Members.Contains(member) || x.Creator.Contains(member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                    int teamIndex = teams.FindIndex(m => m.TeamName == teamName);
                    teams[teamIndex].Members.Add(member);
                }
            }

            foreach (var team in teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var members in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {members}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }
    }
}
