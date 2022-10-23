using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCMDS = int.Parse(Console.ReadLine());

            var registrations = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCMDS; i++)
            {
                string[] command = Console.ReadLine().Split();

                string order = command[0];
                string nameOfRegistration = command[1];
                

                switch (order)
                {
                    case "register":
                        string registrationNumber = command[2];

                        if (registrations.ContainsKey(nameOfRegistration))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {registrations[nameOfRegistration]}");
                        }
                        else
                        {
                            registrations.Add(nameOfRegistration, registrationNumber);

                            Console.WriteLine($"{nameOfRegistration} registered {registrationNumber} successfully");
                        }                        
                        break;

                    case "unregister":
                        if (!registrations.ContainsKey(nameOfRegistration))
                        {
                            Console.WriteLine($"ERROR: user {nameOfRegistration} not found");
                        }
                        else
                        {
                            registrations.Remove(nameOfRegistration);

                            Console.WriteLine($"{nameOfRegistration} unregistered successfully");
                        }

                        break;
                }

            }

            foreach (var registration in registrations)
            {
                Console.WriteLine($"{registration.Key} => {registration.Value}");
            }


        }
    }
}
