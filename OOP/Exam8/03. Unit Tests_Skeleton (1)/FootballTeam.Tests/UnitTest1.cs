using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    [TestFixture]

    public class Tests
    {
        private FootballPlayer player1;
        private FootballTeam team1;

        [SetUp]
        public void Setup()
        {
            player1 = new FootballPlayer("Pesho", 10, "Forward");
            team1 = new FootballTeam("otbor", 15);

        }

        [Test]
        public void CtorShouldInitName()
        {
            string expName = "otbor1";

            FootballTeam team2 = new FootballTeam("otbor1", 25);

            Assert.AreEqual(expName, team2.Name);
        }

        [Test]
        public void CtorShouldInitCap()
        {
            int expCap = 25;

            FootballTeam team2 = new FootballTeam("otbor1", 25);

            Assert.AreEqual(expCap, team2.Capacity);
        }

        [Test]
        public void CtorShouldInitList()
        {
            
            FootballTeam team2 = new FootballTeam("otbor1", 25);

            Assert.AreEqual(0, team2.Players.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrow(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team2 = new FootballTeam(name, 25);
            });
            

        }

        [TestCase(10)]
        [TestCase(0)]
        [TestCase(-5)]
        public void CapShouldThrow(int cap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team2 = new FootballTeam("otbor1", cap);
            });
        }

        [Test]
        public void AddNewPlayerShouldReturn()
        {
            string expString = "Added player Pesho in position Forward with number 10";
            string actualString = team1.AddNewPlayer(player1);

            Assert.AreEqual(expString, actualString);

        }

        [Test]
        public void AddNewPlayerShouldThrow()
        {
            string expString = "No more positions available!";

            for (int i = 1; i < 25; i++)
            {
                team1.AddNewPlayer(player1);
            }

            string actualString = team1.AddNewPlayer(player1);

            Assert.AreEqual(expString, actualString);

        }

        [Test]
        public void PickPlayerShouldReturn()
        {
            FootballPlayer expPlayer = player1;

            team1.AddNewPlayer(player1);

            FootballPlayer actualPlayer = team1.PickPlayer("Pesho");


            Assert.AreEqual(expPlayer, actualPlayer);

        }

        [Test]
        public void PlayerScoreShouldThrow()
        {
            string expString = "Pesho scored and now has 1 for this season!";

            team1.AddNewPlayer(player1);

            string actualString = team1.PlayerScore(10);

            Assert.AreEqual(expString, actualString);

        }
    }
}