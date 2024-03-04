using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name 
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            } 
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get
            {
                return this.firstTeam.AsReadOnly();
            }
        }
        public IReadOnlyList<Person> ReserveTeam
        {
            get
            {
                return this.reserveTeam.AsReadOnly();
            }
        }

        public void AddPlayer(Person person)
        {
            if(person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            return $"First team has {firstTeam.Count} players.{Environment.NewLine}Reserve team has {reserveTeam.Count} players.";
        }
    }
}
