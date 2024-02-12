namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void SetUp()
        {


        }

        [Test]
        public void ConstructorShouldInitializeWarriorNameProperly()
        {
            string expectedName = "Goshko";

            Warrior warrior = new Warrior(expectedName, 100, 100);

            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);

        }

        [Test]
        public void ConstructorShouldInitializeWarriorDamage()
        {
            int expectedDamage = 32;

            Warrior warrior = new Warrior("Goshko", expectedDamage, 100);

            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);

        }

        [Test]
        public void ConstructorShouldInitializeHealthPoints()
        {
            int expectedHP = 100;

            Warrior warrior = new Warrior("Goshko", 55, expectedHP);

            int actualHP = warrior.HP;

            Assert.AreEqual(expectedHP, actualHP);

        }

        [TestCase("Gosho")]
        [TestCase("A")]
        [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz")]
        public void NameSetterShouldSetValueWithValidName(string name)
        {
            Warrior warrior = new Warrior(name, 50, 100);

            string expectedName = name;
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("              ")]
        public void NameSetShouldThrowExceptionWhenInvalidName(string name)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 50, 100);

            }, "Name should not be empty or whitespace!");
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(1500)]
        public void DamageSetterShouldSetValueWithValidDamage(int damage)
        {
            Warrior warrior = new Warrior("Pesho", damage, 100);

            int expectedDamage = damage;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(-5000)]
        [TestCase(-1)]
        [TestCase(0)]
        public void DamageShouldThrowExceptionWhenInvalid(int damage)
        {
            Assert.Throws(typeof(ArgumentException), () =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 100);
            }, "Damage value should be positive!");

        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1000000)]
        public void HPSetterSHouldSetValueWithValidHP(int hp)
        {
            Warrior warrior = new Warrior("Pesho", 29, hp);

            int actualHP = warrior.HP;

            Assert.AreEqual(hp, actualHP);
        }

        [TestCase(-1)]
        [TestCase(-500)]
        [TestCase(-10000)]
        public void HPShouldThrowExceptionWhenInvalid(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pehso", 42, hp);
            }, "HP should not be negative!");
        }

        [Test]
        public void AttackIsSuccessfulWithNoKill()
        {
            int w1HP = 100;
            int w1Damage = 25;
            int w2HP = 100;
            int w2Damage = 50;

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1HP);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2HP);

            int w1ExpectedHp = warrior1.HP - w2Damage;
            int w2ExpectedHp = warrior2.HP - w1Damage;

            warrior1.Attack(warrior2);
            
            int actualW1Hp = warrior1.HP;
            int actualW2Hp = warrior2.HP;

            Assert.AreEqual(w1ExpectedHp, actualW1Hp);
            Assert.AreEqual(w2ExpectedHp, actualW2Hp);
        }

        [TestCase(35)]
        [TestCase(50)]
        public void AttackIsSuccessfulWithKill(int w2Hp)
        {
            int w1Hp = 100;
            int w1damage = 50;
            int w2damage = 30;

            Warrior warrior1 = new Warrior("Pesho", w1damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2damage, w2Hp);

            int w1ExpectedHp = warrior1.HP - w2damage;
            int w2ExpectedHp = 0;

            warrior1.Attack(warrior2);

            int w1ActualHp = warrior1.HP;
            int w2ActualHp = warrior2.HP;

            Assert.AreEqual(w1ExpectedHp, w1ActualHp);
            Assert.AreEqual(w2ExpectedHp, w2ActualHp);
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionWhenHPIsBelowMin(int w1Hp)
        {
            int w2Hp = 100;
            int w2Damage = 50;
            int w1Damage = 45;

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionWhenTheOtherWarriorHpIsBelowMin(int w2Hp)
        {
            int w1Hp = 100;
            int w1Damage = 50;
            int w2Damage = 30;

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);

            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(45, 65)]
        [TestCase(45, 46)]
        public void AttackShouldThrowExceptionWhenHpIsLowerThanDefenderDamage(int w1Hp, int w2Damage)
        {
            int w1Damage = 38;
            int w2Hp = 100;

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            }, "You are trying to attack too strong enemy");
        }
    }
}