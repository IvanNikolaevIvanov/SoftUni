namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Lada", "Samara", 7, 100);

        }

        [Test]
        public void CtorShouldInitializeCarMake()
        {
            string expectedMake = "Lada";

            var newCar = new Car(expectedMake, "Samara", 8.5, 100);

            var actualMake = newCar.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void CtorShouldInitializeCarModel()
        {
            string expectedModel = "Samara";

            var newCar = new Car("Lada", expectedModel, 8.5, 100);

            var actualModel = newCar.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void CtorShouldInitializeCarFuelConsumption()
        {
            double expectedFuelConsumption = 8.5;

            var newCar = new Car("Lada", "Samara", expectedFuelConsumption, 100);

            var actualFuelConsumption = newCar.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void CtorShouldInitializeCarFuelCapacity()
        {
            double expFuelCapacity = 100;

            var newCar = new Car("Lada", "Samara", 8.5, expFuelCapacity);

            var actualFuelCapacity = newCar.FuelCapacity;

            Assert.AreEqual(expFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void CtorShouldSetFuelAmmoutToZero()
        {
            var newCar = new Car("Lada", "Samara", 8.5, 100);

            double actualFuelAmmout = newCar.FuelAmount;

            Assert.AreEqual(0, actualFuelAmmout);
        }

        [TestCase("Lada")]
        [TestCase("Opel12345")]
        [TestCase("asdfasdfasdfasdfASDFSADASNFNJKKJNDF ")]
        public void MakeSetterShouldSetValidMake(string make)
        {
            string expectedMake = make;

            var newCar = new Car(make, "Samara", 8.5, 100);

            string actualMake = newCar.Make;

            Assert.AreEqual(expectedMake, actualMake);

        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeSetterShouldThrowExceptionIfStringNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(make, "Samara", 8.5, 100);
            }, "Make cannot be null or empty!");

        }

        [TestCase("Samara")]
        [TestCase("Opel12345")]
        [TestCase("asdfasdfasdfasdfASDFSADASNFNJKKJNDF ")]
        public void ModelSetterShouldSetValidModel(string model)
        {
            string expectedModel = model;

            var newCar = new Car("Lada", model, 8.5, 100);

            string actualModel = newCar.Model;

            Assert.AreEqual(expectedModel, actualModel);

        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelSetterShouldThrowExceptionIfStringNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Lada", model, 8.5, 100);
            }, "Model cannot be null or empty!");

        }

        [TestCase(1)]
        [TestCase(1.1)]
        [TestCase(19.4)]
        [TestCase(20.4123)]
        [TestCase(2995.493900)]
        [TestCase(0.2)]
        public void FuelConsumptionSetterShouldSetValidDouble(double fuelCons)
        {
            double expectedFuelCons = fuelCons;

            Car car = new Car("Lada", "Samara", fuelCons, 100);

            double actualFuelCons = car.FuelConsumption;

            Assert.AreEqual(actualFuelCons, expectedFuelCons);  

        }

        [TestCase(0)]
        [TestCase(- 0)]
        [TestCase(- 0.234324)]
        [TestCase(- 5)]
        [TestCase(- 5543.0)]
        [TestCase(double.MinValue)]
        public void FuelConsumptionSetterShouldThrowExceptionWhenNegativeOrZero(double fuelCons)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Lada", "Samara", fuelCons, 100);
            }, "Fuel consumption cannot be zero or negative!");

        }


        [TestCase(1)]
        [TestCase(1.1)]
        [TestCase(19.4)]
        [TestCase(20.4123)]
        [TestCase(double.MaxValue)]
        [TestCase(0.2)]
        public void FuelCapacitySetterShouldSetValidDouble(double fuelCap)
        {
            double expfuelCap = fuelCap;

            Car car = new Car("Lada", "Samara", 4.5, fuelCap);

            double actualfuelCap = car.FuelCapacity;

            Assert.AreEqual(actualfuelCap, expfuelCap);

        }

        [TestCase(0)]
        [TestCase(-0)]
        [TestCase(-0.234324)]
        [TestCase(-5)]
        [TestCase(-5543.0)]
        [TestCase(double.MinValue)]
        public void FuelCapacitySetterShouldThrowExceptionWhenZeroOrNegative(double fuelCap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Lada", "Samara", 9.5, fuelCap);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(1.1)]
        [TestCase(20)]
        [TestCase(40.2313)]
        [TestCase(double.MaxValue)]
        public void RefuelShouldIncreaseFuelAmmount(double fuelToRefuel)
        {
            double expextedFuelAmmount = 0;


            if (car.FuelAmount + fuelToRefuel <= car.FuelCapacity)
            {
                expextedFuelAmmount = car.FuelAmount + fuelToRefuel;

            }
            else 
            {
                expextedFuelAmmount = car.FuelCapacity;
            }
            

            car.Refuel(fuelToRefuel);

            double actualFuelAmmount = car.FuelAmount;

            Assert.AreEqual(expextedFuelAmmount, actualFuelAmmount);

        }

        [TestCase(0)]
        [TestCase(-1.234)]
        [TestCase(-50)]
        [TestCase(double.MinValue)]
        public void RefuelShouldThrowExceptionWhenZeroOrNegative(double fuelToRefuel)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");

        }

        [Test]
        public void DriveShouldDecreaseFuelAmmountWhenFuelNeededLessThanFuelAmmount()
        {
            car.Refuel(50);
            double distance = 100;
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            double expectedFuelAmmount = car.FuelAmount - fuelNeeded;

            car.Drive(distance);

            double actualFuelAmmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmmount, actualFuelAmmount);

        }

        [Test]
        public void DriveShouldThrowExceptionWhenFuelNeededTooMuch()
        {
            car.Refuel(20);
            double distance = 1000;

            Assert.Throws<InvalidOperationException>(() =>
            {

                car.Drive(distance);
            }, "You don't have enough fuel to drive!");


        }
    }
}