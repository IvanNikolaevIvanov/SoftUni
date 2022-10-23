using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            var teams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] currentTeam = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                string creator = currentTeam[0];
                string teamName = currentTeam[1];

                if (teams.Any(curTeam => curTeam.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(curTeam => curTeam.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    var team = new Team();
                    team.TeamName = teamName;
                    team.Creator = creator;
                    team.Members = new List<string>();

                    teams.Add(team);

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");

                }
            }

            while (true)
            {
                string[] newMembers = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);

                if (newMembers[0] == "end of assignment")
                {
                    break;
                }

                string newMember = newMembers[0];
                string team = newMembers[1];

                if (teams.All(curTeam => curTeam.TeamName != team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teams.Any(team => team.Members.Contains(newMember)) || teams.Any(team => team.Creator == newMember))
                {
                    Console.WriteLine($"Member {newMember} cannot join team {team}!");
                }
                else
                {
                    var currTeam = teams.Find(curteam => curteam.TeamName == team);
                    currTeam.Members.Add(newMember);
                }
            }

            var finalTeamsList = teams.Where(x => x.Members.Count > 0);

            var disbandedTeams = teams.Where(team => team.Members.Count == 0);

            foreach (var team in finalTeamsList.OrderByDescending(x => x.Members.Count)
                .ThenBy(y => y.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine($"Teams to disband:");

            foreach (var team in disbandedTeams.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }

        }
    }

    class Team
    {


        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

    }
}
