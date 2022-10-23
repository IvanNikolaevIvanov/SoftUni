using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            
            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }

                var vehicle = new Vehicle();
                vehicle.Type = command[0];
                vehicle.Model = command[1];
                vehicle.Color = command[2];
                vehicle.Horsepower = command[3];

                vehicles.Add(vehicle);

            }

            string order = Console.ReadLine();

            

            while (order != "Close the Catalogue")
            {
                                               
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.Model == order)
                    {
                        if (vehicle.Type == "car")
                        {
                            Console.WriteLine($"Type: Car");
                            Console.WriteLine($"Model: {vehicle.Model}");
                            Console.WriteLine($"Color: {vehicle.Color}");
                            Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                        }
                        else
                        {
                            Console.WriteLine($"Type: Truck");
                            Console.WriteLine($"Model: {vehicle.Model}");
                            Console.WriteLine($"Color: {vehicle.Color}");
                            Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                        }
                        
                    }
                }

                order = Console.ReadLine();
            }

            List<Vehicle> trucks = new List<Vehicle>();
            List<Vehicle> cars = new List<Vehicle>();

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Type == "truck")
                {
                    trucks.Add(vehicle);
                }
                else
                {
                    cars.Add(vehicle);
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {cars.Average(curCar => double.Parse(curCar.Horsepower)):f2}.");

            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");

            }
            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucks.Average(curTruck => double.Parse(curTruck.Horsepower)):f2}.");

            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");

            }

        }
    }

    class Vehicle
    {
        //"{typeOfVehicle} {model} {color} {horsepower}"
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Horsepower { get; set; }
    }
}
