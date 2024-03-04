using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] inputElements = input.Split(';');
                string command = inputElements[0];
                try
                {
                    switch (command)
                    {
                        case "Team":
                            Team newTeam = new Team(inputElements[1]);
                            teams.Add(newTeam);
                            break;
                        case "Add":
                            Team teamForAddingPlayer = teams.FirstOrDefault(t => t.Name == inputElements[1]);
                            if (teamForAddingPlayer == null)
                            {
                                throw new ArgumentException($"Team {inputElements[1]} does not exist.");
                            }
                            else
                            {
                                teamForAddingPlayer.AddPlayer(inputElements[2], int.Parse(inputElements[3]), int.Parse(inputElements[4]), int.Parse(inputElements[5]), int.Parse(inputElements[6]), int.Parse(inputElements[7]));
                            }
                            break;
                        case "Remove":
                            Team teamForRemovingPlayer = teams.FirstOrDefault(t => t.Name == inputElements[1]);
                            teamForRemovingPlayer.RemovePlayer(inputElements[2]);

                            break;
                        case "Rating":
                            Team team = teams.FirstOrDefault(t => t.Name == inputElements[1]);
                            if(team == null)
                            {
                                throw new ArgumentException($"Team {inputElements[1]} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine(team.PrintTeamRating());
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
