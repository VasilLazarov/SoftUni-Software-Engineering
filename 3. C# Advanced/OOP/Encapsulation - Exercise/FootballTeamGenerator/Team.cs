using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        //private int rating;
        private readonly List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name 
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.SkillLevel);
                }
                return 0;
            }
        }

        public void AddPlayer(string playerName, int enduranse, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(playerName, enduranse, sprint, dribble, passing, shooting);

            players.Add(player);

        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);
            if(player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }
            players.Remove(player);
        }
        public string PrintTeamRating()
        {
            return $"{Name} - {Math.Round(Rating, MidpointRounding.AwayFromZero)}";
        }
    }
}
