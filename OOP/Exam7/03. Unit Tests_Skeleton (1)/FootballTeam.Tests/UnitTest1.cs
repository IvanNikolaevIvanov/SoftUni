using NUnit.Framework;
using System.Net.Http.Headers;
using FootballTeam;
using System;

namespace FootballTeam.Tests
{
    [TestFixture]

    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Pesho", 10, "Forward");
            team = new FootballTeam("otbor", 15);

        }

        [Test]
        public void CtorShouldInitializeName()
        {
            string expName = "Gosho";
            FootballTeam team1 = new FootballTeam("Gosho", 15);

            Assert.AreEqual(expName, team1.Name);
        }

        [Test]
        public void CtorShouldInitializeCap()
        {
            int expCap = 15;
            FootballTeam team1 = new FootballTeam("Gosho", 15);

            Assert.AreEqual(expCap, team1.Capacity);
        }

        [Test]
        public void CtorShouldInitializeList()
        {            

            Assert.AreEqual(0, team.Players.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrow(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team1 = new FootballTeam(name, 15);

            });

        }

        [TestCase(14)]
        [TestCase(10)]
        [TestCase(0)]
        [TestCase(-5)]
        public void CapShouldThrow(int cap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team1 = new FootballTeam("Pesho", cap);

            });

        }

        [Test]
        public void AddNewPlayerShouldAdd()
        {
            string expString = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            string actualStr = team.AddNewPlayer(player);

            Assert.AreEqual(expString, actualStr);
        }

        [Test]
        public void AddNewPlayerShouldThrwo()
        {
            string expStr = "No more positions available!";
            for (int i = 1; i <= 15; i++)
            {
                team.AddNewPlayer(player);

            }
            
            string actualStr = team.AddNewPlayer(player);

            Assert.AreEqual(expStr, actualStr);
            
        }

        [Test]
        public void PickPlayerShouldPick()
        {
            var expPlayer = player;
            team.AddNewPlayer(player);

            var actualPlayer = team.PickPlayer("Pesho");

            Assert.AreEqual(expPlayer, actualPlayer);
        }

        [Test]
        public void PlayerScore()
        {
            team.AddNewPlayer(player);

            string expStr = $"{player.Name} scored and now has 1 for this season!";

            string actualStr = team.PlayerScore(10);

            Assert.AreEqual(expStr, actualStr);
        }
    }
}