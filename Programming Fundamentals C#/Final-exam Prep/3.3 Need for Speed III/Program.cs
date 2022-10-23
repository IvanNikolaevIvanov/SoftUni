using System;
using System.Collections.Generic;

namespace _3._3_Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var carList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputCar = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                                
                var newCar = new Car();
                newCar.brand = inputCar[0];
                newCar.mileage = int.Parse(inputCar[1]);
                newCar.fuel = int.Parse(inputCar[2]);

                carList.Add(newCar);

            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Stop")
                {
                    break;
                }

                string command = commands[0];
                string carBrand = commands[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(commands[2]);
                    int fuel = int.Parse(commands[3]);

                    foreach (var car in carList)
                    {
                        if (car.brand == carBrand)
                        {
                            if (car.fuel < fuel)
                            {
                                Console.WriteLine($"Not enough fuel to make that ride");
                            }
                            else
                            {
                                car.fuel -= fuel;
                                car.mileage += distance;

                                Console.WriteLine($"{car.brand} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            }

                            if (car.mileage >= 100_000)
                            {
                                Console.WriteLine($"Time to sell the {car.brand}!");

                                carList.Remove(car);

                                break;
                                
                            }
                        }


                    }

                }

                if (command == "Refuel")
                {
                    int fuel = int.Parse(commands[2]);
                    
                    foreach (var car in carList)
                    {
                        if (car.brand == carBrand)
                        {
                            int originalFuel = car.fuel;
                            
                            car.fuel += fuel;

                            if (car.fuel > 75)
                            {
                                car.fuel = 75;
                            }

                            Console.WriteLine($"{car.brand} refueled with {car.fuel - originalFuel} liters");
                        }


                    }
                }

                if (command == "Revert")
                {
                    int kilometersToRevert = int.Parse(commands[2]);


                    foreach (var car in carList)
                    {
                        if (car.brand == carBrand)
                        {
                            car.mileage -= kilometersToRevert;
                            if (car.mileage < 10_000)
                            {
                                car.mileage = 10_000;
                            }
                            else
                            {
                                Console.WriteLine($"{car.brand} mileage decreased by {kilometersToRevert} kilometers");
                            }
                        }


                    }
                }


            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.brand} -> Mileage: {car.mileage} kms, Fuel in the tank: {car.fuel} lt.");
            }
        }
    }

    class Car
    {
        public string brand { get; set; }
        public int mileage { get; set; }
        public int fuel { get; set; }


    }
}
