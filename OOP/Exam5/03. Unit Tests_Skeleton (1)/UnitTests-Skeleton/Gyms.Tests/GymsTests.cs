using NUnit.Framework;
using System;
using System.Drawing;

namespace Gyms.Tests
{

    [TestFixture]
    public class GymsTests
    {
        Gym gym;
        Athlete atlet;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym("MoqGym", 1);
            atlet = new Athlete("Az");

        }

        [Test]
        public void CtorShouldInitializeName()
        {
            string exptName = "Gosho";

            Gym gym = new Gym("Gosho", 5);

            Assert.AreEqual(exptName, gym.Name);

        }

        [Test]
        public void CtorShouldInitializeCapacity()
        {
            int exptCap = 10;

            Gym gym = new Gym("Gosho", 10);

            Assert.AreEqual(exptCap, gym.Capacity);

        }

        [Test]
        public void CtorShouldInitializeList()
        {

            Gym gym = new Gym("Gosho", 10);

            Assert.AreEqual(0, gym.Count);

        }

        [TestCase(" ")]
        [TestCase("a")]
        [TestCase("AAaa")]
        [TestCase("AAaa fasdf fdsfasdf adsfc")]
        public void NameSetterShouldSetName(string name)
        {
  

            Gym gym = new Gym(name, 5);

            Assert.AreEqual(name, gym.Name);


        }
        [TestCase(null)]
        [TestCase("")]
        
        public void NameSetterShouldThrow(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 5);

            });

        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(893)]
        public void CapSetterShouldSetCap(int size)
        {
            Gym gym = new Gym("Pesho", size);

            Assert.AreEqual(size, gym.Capacity);

        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-55)]
        [TestCase(-893)]
        public void CapSetterShouldThrow(int size)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Pesho", size);

            });

        }

        [Test]
        public void CountShouldWork()
        {
            Gym gym = new Gym("Salon", 1);
            Athlete atlet = new Athlete("Ivan");

            gym.AddAthlete(atlet);

            Assert.AreEqual(1, gym.Count);


        }

        [Test]
        public void AddShouldAdd()
        {
            Gym gym12 = new Gym("Salon1", 10);

            Athlete athlete13 = new Athlete("Gogi");

            gym12.AddAthlete(athlete13);

            Assert.AreEqual(1, gym12.Count);

        }

        [Test]
        public void AddShouldShouldThrow()
        {
            Gym gym = new Gym("Pesho", 1);

            Athlete athlete1 = new Athlete("Pesho");
            gym.AddAthlete(athlete1);

            Athlete athlete2 = new Athlete("Goshkata");

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);

            });

        }

        [Test]
        public void RemoveShouldRemove()
        {
            Gym gym = new Gym("Pesho", 1);

            Athlete athlete1 = new Athlete("Pesho");

            gym.AddAthlete(athlete1);
            gym.RemoveAthlete("Pesho");

            Assert.AreEqual(0, gym.Count);

        }

        [Test]
        public void RemoveShouldThrow()
        {
            Gym gym = new Gym("Pesho", 1);
            Athlete athlete2 = new Athlete("Goshkata");

            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Yordan");
            });     

        }

        [Test]
        public void InjureAthleteShouldWork()
        {
            Gym gym = new Gym("Salon", 1);
            Athlete atlet = new Athlete("Ivan");

            bool expInjury = true;

            gym.AddAthlete(atlet);

            gym.InjureAthlete("Ivan");

            Assert.AreEqual(expInjury, atlet.IsInjured);

        }

        [Test]
        public void InjureAthleteShouldThrow()
        {
            Gym gym = new Gym("Salon", 1);
            Athlete atlet = new Athlete("Ivan");

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Petkan");

            });

        }

        [Test]
        public void ReportShouldWork()
        {

            Gym gym = new Gym("Salon", 1);
            Athlete atlet = new Athlete("Ivan");
            gym.AddAthlete(atlet);

            string expString = "Active athletes at Salon: Ivan";
            string actualString = gym.Report();

            Assert.AreEqual(expString, actualString);


        }

        [Test]
        public void ReportShouldNotReturnInjured()
        {

            Gym gym = new Gym("Salon", 2);
            Athlete atlet = new Athlete("Ivan");
            Athlete atlet2 = new Athlete("Peshko");

            gym.AddAthlete(atlet);
            gym.AddAthlete(atlet2);
            gym.InjureAthlete("Peshko");


            string expString = "Active athletes at Salon: Ivan";
            string actualString = gym.Report();

            Assert.AreEqual(expString, actualString);


        }

    }
}
