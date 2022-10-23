using System;
using System.Collections.Generic;

namespace _3._0_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            var towns = new Dictionary<string, List<int>>();

            while (true)
            {
                string[] targets = Console.ReadLine().Split("||");
                if (targets[0] == "Sail")
                {
                    break;
                }

                string name = targets[0];
                int population = int.Parse(targets[1]);
                int gold = int.Parse(targets[2]);

                if (!towns.ContainsKey(name))
                {
                    towns.Add(name, new List<int> { population, gold });
                }
                else
                {
                    towns[name][0] += population;
                    towns[name][1] += gold;
                }

            }


            while (true)
            {
                string[] commands = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "End")
                {
                    break;
                }

                string command = commands[0];

                switch (command)
                {
                    case "Plunder":

                        Plunder(commands[1], int.Parse(commands[2]), int.Parse(commands[3]), towns);

                        break;
                    case "Prosper":

                        Prosper(commands[1], int.Parse(commands[2]), towns);

                        break;

                }

            }


            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns)
                {
                    Console.WriteLine($"{town.Key.ToString()} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");

                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            
        }

        static void Plunder(string town, int people, int gold, Dictionary<string, List<int>> towns)
        {

            if (towns[town][0] > people && towns[town][1] > gold)
            {
                towns[town][0] -= people;
                towns[town][1] -= gold;

                Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
            }
            else if (towns[town][0] <= people || towns[town][1] <= gold)
            {
                Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                towns.Remove(town);

                Console.WriteLine($"{town} has been wiped off the map!");
            }

            
        }
        
        static void Prosper(string town, int gold, Dictionary<string, List<int>> towns)
        {
            if (gold < 0)
            {
                Console.WriteLine($"Gold added cannot be a negative number!");
                return;
            }
            else
            {
                towns[town][1] += gold;

                Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town][1]} gold.");
            }
        }

    }
}
