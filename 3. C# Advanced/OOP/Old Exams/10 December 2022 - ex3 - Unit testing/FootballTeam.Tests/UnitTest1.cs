using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        //[TestCase("Vasil", 10, "Forward")]
        //[TestCase("Marto", 21, "Midfielder")]
        //[TestCase("Ivo", 1, "Goalkeeper")]
        //public void Test_FootballPlayer_ConstructorShouldSetDataCorrectly(string name, int number, string position)
        //{
        //    player = new FootballPlayer(name, number, position);
        //
        //    Assert.IsNotNull(player);
        //    Assert.That(player.Name, Is.EqualTo(name));
        //    Assert.That(player.PlayerNumber, Is.EqualTo(number));
        //    Assert.That(player.Position, Is.EqualTo(position));
        //
        //    Assert.That(player.ScoredGoals, Is.EqualTo(0));
        //}
        //
        //[TestCase("")]
        //[TestCase(null)]
        //public void Test_FootballPlayer_ConstructorShouldThrowException_WhenNameIsNullOrEmpty(string name)
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        player = new FootballPlayer(name, 1, "Goalkeeper");
        //    }, "Name cannot be null or empty!");
        //}
        //
        //[TestCase(0)]
        //[TestCase(22)]
        //[TestCase(-5)]
        //public void Test_FootballPlayer_ConstructorShouldThrowException_WhenNumberIsInvalid(int number)
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        player = new FootballPlayer("Vasil", number, "Goalkeeper");
        //    }, "Player number must be in range [1,21]");
        //}
        //
        //
        //[TestCase("")]
        //[TestCase(null)]
        //[TestCase(" ")]
        //[TestCase("Coach")]
        //[TestCase("fsdfjksdf")]
        //public void Test_FootballPlayer_ConstructorShouldThrowException_WhenNumberIsInvalid(string position)
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        player = new FootballPlayer("Vasil", 10, position);
        //    }, "Invalid Position");
        //}
        //
        //
        //[Test]
        //public void Test_FootballPlayer_MethodTestShouldIncreaseFieldScoreGoals()
        //{
        //    player = new FootballPlayer("Vasil", 10, "Forward");
        //
        //    Assert.That(player.ScoredGoals, Is.EqualTo(0));
        //    player.Score();
        //    player.Score();
        //    player.Score();
        //    Assert.That(player.ScoredGoals, Is.EqualTo(3));
        //}

        [TestCase("CampNou", 100)]
        [TestCase("BernaLeo", 15)]
        public void Test_FootballTeam_ConstructorShouldSetDataCorrectly(string name, int capacity)
        {
            team = new FootballTeam(name, capacity);

            Assert.IsNotNull(team);
            Assert.That(team.Name, Is.EqualTo(name));
            Assert.That(team.Capacity, Is.EqualTo(capacity));
            Assert.That(team.Players.Count, Is.EqualTo(0));

            Type type = team.Players.GetType();
            Type expectedType = typeof(List<FootballPlayer>);

            Assert.That(type, Is.EqualTo(expectedType));
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_FootballTeam_ConstructorShouldThrowException_WhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(name, 50);
            }, "Name cannot be null or empty!");
        }

        [TestCase(14)]
        [TestCase(-5)]
        public void Test_FootballTeam_ConstructorShouldThrowException_WhenCapacityIsInvalid(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam("CampNou", capacity);
            }, "Capacity min value = 15");
        }

        [Test]
        public void Test_FootballTeam_MethodAddPlayerShouldAddCorrectlyPlayerAndReturnString()
        {
            team = new FootballTeam("CampNou", 15);
            player = new FootballPlayer("Vasil", 10, "Goalkeeper");
            //List<FootballPlayer> expectedPlayers = new List<FootballPlayer>();

            string actualOutputString = team.AddNewPlayer(player);
            //expectedPlayers.Add(player);
            string expectedOutputString = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";

            //CollectionAssert.AreEquivalent(expectedPlayers, team.Players);
            Assert.That(actualOutputString, Is.EqualTo(expectedOutputString));
        }

        [Test]
        public void Test_FootballTeam_MethodAddPlayerShouldThrowException_WhenDontHaveAvailablePositionsToAddPlayer()
        {
            team = new FootballTeam("CampNou", 15);
            for (int i = 1; i <= 15; i++)
            {
                player = new FootballPlayer($"Vasil{i}", 1 + i, $"Goalkeeper");
                team.AddNewPlayer(player);
            }

            player = new FootballPlayer("Vasil16", 20, "Goalkeeper");
            string actualOutputString = team.AddNewPlayer(player);
            string expectedOutputString = "No more positions available!";

            Assert.That(actualOutputString, Is.EqualTo(expectedOutputString));
        }

        [Test]
        public void Test_FootballTeam_MethodPickPlayer_ShouldReturnCorrectPlayer()
        {
            team = new FootballTeam("CampNou", 15);
            player = new FootballPlayer("Vasil", 10, "Goalkeeper");
            team.AddNewPlayer(player);
            FootballPlayer player2 = new FootballPlayer("Marto", 11, "Goalkeeper");
            team.AddNewPlayer(player2);

            FootballPlayer expectedPlayer = team.PickPlayer("Vasil");

            Assert.That(player, Is.SameAs(expectedPlayer));
        }

        [Test]
        public void Test_FootballTeam_MethodPlayerScore_ShouldReturnCorrectInfoForScoringPlayer()
        {
            team = new FootballTeam("CampNou", 15);
            player = new FootballPlayer("Vasil", 10, "Goalkeeper");
            team.AddNewPlayer(player);
            FootballPlayer player2 = new FootballPlayer("Marto", 11, "Goalkeeper");
            team.AddNewPlayer(player2);

            int scoringPlayerNumber = 10;
            FootballPlayer scoringPlayer = team.Players.FirstOrDefault(p => p.PlayerNumber == scoringPlayerNumber);
            string actualOutputString = team.PlayerScore(scoringPlayerNumber);
            string expectedOutputString = $"{player.Name} scored and now has {player.ScoredGoals} for this season!";
            Assert.That(actualOutputString, Is.EqualTo(expectedOutputString));

        }



    }
}