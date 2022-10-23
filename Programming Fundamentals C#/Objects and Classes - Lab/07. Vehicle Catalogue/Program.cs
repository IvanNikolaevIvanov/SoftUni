using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            while (true)
            {
                string[] commands = Console.ReadLine().Split('/');
                if (commands[0] == "end")
                {
                    break;
                }

                string type = commands[0];

                switch (type)
                {
                    case "Truck":
                        Truck truck = new Truck
                        {
                            Brand = commands[1],
                            Model = commands[2],
                            Weight = int.Parse(commands[3])

                        };

                        catalog.trucks.Add(truck);

                        break;
                    case "Car":
                        Car car = new Car
                        {
                            Brand = commands[1],
                            Model = commands[2],
                            HorsePower = int.Parse(commands[3])
                        };

                        catalog.cars.Add(car);

                        break;

                }
            }

            if (catalog.cars.Count > 0)
            {
                List<Car> orderedCars = catalog.cars.OrderBy(car => car.Brand).ToList();

                Console.WriteLine("Cars:");

                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalog.trucks.OrderBy(truck => truck.Brand).ToList();

                Console.WriteLine("Trucks:");
                
                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");

                }
            }


        }

        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }

        }

        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }

        }

        class Catalog
        {
            public Catalog()
            {
                this.cars = new List<Car>();
                this.trucks = new List<Truck>();

            }

            public List<Car> cars = new List<Car>();
            public List<Truck> trucks = new List<Truck>();
        }
    }
}
