namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]

    public class AquariumsTests
    {

        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Aqua", 1);
        }

        [Test]
        public void CtorShouldInitializeName()
        {
            string expName = "Aqua1";
            Aquarium aquarium = new Aquarium(expName, 5);

            Assert.AreEqual(expName, aquarium.Name);
        }

        [Test]
        public void CtorShouldInitializeCap()
        {
            int expCap = 10;
            Aquarium aquarium = new Aquarium("Pesho", expCap);

            Assert.AreEqual(expCap, aquarium.Capacity);
        }

        [Test]
        public void CtorShouldInitializeList()
        {
            
            Aquarium aquarium = new Aquarium("Pesho", 5);

            Assert.AreEqual(0, aquarium.Count);
        }

        [TestCase(" ")]
        [TestCase("a")]
        [TestCase("AAAA")]
        [TestCase("AAAA bbbb BBBB asdfasd")]
        public void NameShouldSetName(string name)
        {

            Aquarium aquarium = new Aquarium(name, 5);

            Assert.AreEqual(name, aquarium.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        
        public void NameShouldThrow(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 5);

            });           
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(5674)]
        public void CapShouldSetCap(int cap)
        {

            Aquarium aquarium = new Aquarium("Pesho", cap);

            Assert.AreEqual(cap, aquarium.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-2387)]

        public void CapShouldThrow(int cap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Pesho", cap);

            });
        }

        [Test]
        public void AddShouldAdd()
        {
            var fishToAdd = this.fish;
            aquarium.Add(fish);

            Assert.AreEqual(fishToAdd, this.fish);

        }

        [Test]
        public void AddShouldThrow()
        {
            var fishToAdd = this.fish;
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fishToAdd);
            });

        }

        [Test]
        public void RemoveShouldRemove()
        {
            var fishToRemove = this.fish;
            aquarium.Add(fish);
            aquarium.RemoveFish("Pesho");

            Assert.AreEqual(0, aquarium.Count);

        }

        [Test]
        public void RemoveShouldThrow()
        {

            aquarium.Add(fish);
            aquarium.RemoveFish("Pesho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Gosho");
            });

        }

        [Test]
        public void SellFishShouldSell()
        {
            var fishToSell = this.fish;
            aquarium.Add(fish);

            Assert.AreEqual(fishToSell, aquarium.SellFish("Pesho"));
        }

        [Test]
        public void SellFishShouldThrow()
        {

            aquarium.Add(fish);
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Gosho");
            });

        }

        [Test]
        public void ReportShouldWork()
        {
            aquarium.Add(fish);

            string expString = "Fish available at Aqua: Pesho";

            string actualReport = aquarium.Report();

            Assert.AreEqual(expString, actualReport);

        }
    }
}
