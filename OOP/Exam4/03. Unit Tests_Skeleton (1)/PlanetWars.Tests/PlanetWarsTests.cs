using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponConstructorShouldInitializeName()
            {
                string expectedName = "chuk";
                Weapon weapon = new Weapon(expectedName, 10, 10);

                Assert.AreEqual(expectedName, weapon.Name);
            }

            [Test]
            public void WeaponConstructorShouldInitializePrice()
            {
                int expectedPrice = 10;
                Weapon weapon = new Weapon("chuk", expectedPrice, 10);

                Assert.AreEqual(expectedPrice, weapon.Price);
            }

            [Test]
            public void WeaponConstructorShouldInitializeDestructionLevel()
            {
                int expectedDestructionLevel = 10;
                Weapon weapon = new Weapon("chuk", 10, expectedDestructionLevel);

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }

            [TestCase(- 0.1)]
            [TestCase(- 1)]
            [TestCase(- 5)]
            [TestCase(- 500.4)]
            public void PriceSetterShouldThrow(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("chuk", price, 10);

                });

            }

            [Test]
            public void IncreaseDestructionLevelShouldIncrease()
            {
                Weapon weapon = new Weapon("chuk", 10, 10);

                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(11, weapon.DestructionLevel);
            }

            [TestCase(10)]
            [TestCase(11)]
            [TestCase(169)]
            public void IsNuclearShouldWorkWhenTrue(int destruction)
            {

                Weapon weapon = new Weapon("chuk", 10, destruction);

                Assert.IsTrue(weapon.IsNuclear);

            }
            [TestCase(9)]
            [TestCase(5)]
            [TestCase(-169)]
            public void IsNuclearShouldWorkWhenFalse(int destruction)
            {

                Weapon weapon = new Weapon("chuk", 10, destruction);

                Assert.IsTrue(!weapon.IsNuclear);

            }

            [Test]
            public void PlanetConstructorShouldInitializeName()
            {
                string expectedName = "Mars";
                Planet planet = new Planet(expectedName, 10);

                Assert.AreEqual(expectedName, planet.Name);
            }

            [Test]
            public void PlanetConstructorShouldInitializeBudget()
            {
                int expectedBudget = 10;
                Planet planet = new Planet("Mars", expectedBudget);
                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [Test]
            public void PlanetConstructorShouldInitializeList()
            {
                
                Planet planet = new Planet("Mars", 10);
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [TestCase(null)]
            [TestCase("")]
            public void NameSetterShouldThrow(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 10);
                });

            }

            [TestCase(-0.1)]
            [TestCase(-1)]
            [TestCase(-5)]
            [TestCase(-556.765)]
            public void BudgetSetterShouldThrow(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Mars", budget);
                });

            }

            [Test]
            public void MilitaryPowerRatioShouldReturnSum()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 1);
                Weapon weapon2 = new Weapon("tesla", 1, 1);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(2, planet.MilitaryPowerRatio);

            }

            [TestCase(0.1)]
            [TestCase(1)]
            [TestCase(-5)]
            [TestCase(556.765)]
            public void ProfitShouldAddAMountToBudget(double ammount)
            {
                Planet planet = new Planet("Mars", 10);

                double expectedAmmount = planet.Budget + ammount;

                planet.Profit(ammount);

                Assert.AreEqual(expectedAmmount, planet.Budget );
            }

            [Test]
            public void SpendFundsShouldWork()
            {
                Planet planet = new Planet("Mars", 10);
                planet.SpendFunds(5.5);

                Assert.AreEqual(4.5, planet.Budget);
            }

            [Test]
            public void SpendFundsShouldThrow()
            {
                Planet planet = new Planet("Mars", 10);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(55.5);
                });
             
            }

            [Test]
            public void AddWeaponShouldAdd()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 1);

                planet.AddWeapon(weapon1);

                Assert.AreEqual(1, planet.Weapons.Count);

            }

            [Test]
            public void AddWeaponShouldThrow()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 1);

                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon1);
                });

            }

            [Test]
            public void RemoveWeaponShouldRemove()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 1);
                Weapon weapon2 = new Weapon("tesla", 1, 1);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon("tesla");

                Assert.IsTrue(planet.Weapons.Count == 1);

            }

            [Test]
            public void RemoveWeaponShouldNotThrow()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 1);
                Weapon weapon2 = new Weapon("tesla", 1, 1);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon("kopie");

                Assert.IsTrue(planet.Weapons.Count == 2);

            }

            [Test]
            public void UpgradeWeaponShouldUpgrade()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 1);
                Weapon weapon2 = new Weapon("tesla", 1, 1);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.UpgradeWeapon("tesla");

                Assert.AreEqual(2, weapon2.DestructionLevel);

            }

            [Test]
            public void UpgradeWeaponShouldThrow()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 1);

                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("tesla");
                });

            }

            [Test]
            public void DestructOponentSHouldReturn()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 10);
                planet.AddWeapon(weapon1);

                Planet opponent = new Planet("Zemq", 10);
                Weapon weapon2 = new Weapon("sopa", 1, 9);
                opponent.AddWeapon(weapon2);

                string expString = $"Zemq is destructed!";

                Assert.AreEqual(expString, planet.DestructOpponent(opponent));

            }

            [Test]
            public void DestructOponentShouldThrow()
            {
                Planet planet = new Planet("Mars", 10);
                Weapon weapon1 = new Weapon("chuk", 1, 10);
                planet.AddWeapon(weapon1);

                Planet opponent = new Planet("Zemq", 10);
                Weapon weapon2 = new Weapon("sopa", 1, 123);
                opponent.AddWeapon(weapon2);

                

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponent);
                });

            }
        }
    }
}
