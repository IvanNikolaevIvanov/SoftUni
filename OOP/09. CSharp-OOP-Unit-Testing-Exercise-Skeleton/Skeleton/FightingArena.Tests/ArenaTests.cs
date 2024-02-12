namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void CtorShouldInitializeWarriorCollection()
        {
            Arena ctorArena = new Arena();

            Assert.IsNotNull(ctorArena.Warriors);
        }

        [Test]
        public void ArenaShouldEnrollNewWarrior()
        {
            Warrior newWarrior = new Warrior("Peshkata", 50, 100);

            this.arena.Enroll(newWarrior);

            bool isWarriorEnrolled = this.arena.Warriors
                .Contains(newWarrior);

            Assert.IsTrue(isWarriorEnrolled);
        }

        [Test]
        public void EnrollingExistantWarriorShouldThrowException()
        {
            Warrior warrior1 = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior2);

            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void CountShouldReturnWarriorsCount()
        {
            Warrior warrior1 = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 40, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            int expectedCount = 2;

            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnZeroWhenThereAreNoWarriors()
        {
            int expectedCount = 0;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightShouldReturnExceptionWhenAttackerIsNull()
        {
            Warrior warrior1 = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 40, 100);

            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Gosho");
            });

        }

        [Test]
        public void FightShouldReturnExceptionWhenDeffenderIsNull()
        {
            Warrior warrior1 = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 40, 100);

            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Gosho");
            });

        }

        [Test]
        public void FightShouldBeSuccessfulWhenWarriorsExist()
        {
            Warrior warrior1 = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 40, 100);

            int expectedW1Hp = 60;
            int expectedW2Hp = 50;

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight("Pesho", "Gosho");

            int w1ActualHp = arena.Warriors.First(w => w.Name == warrior1.Name).HP;
            int w2ActualHp = arena.Warriors.First(w => w.Name == warrior2.Name).HP;

            Assert.AreEqual(expectedW1Hp, w1ActualHp);
            Assert.AreEqual(expectedW2Hp, w2ActualHp);

        }
    }
}
