using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._5_Wild_Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfAnimals = new List<Animal>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "EndDay")
                {
                    break;
                }

                string command = commands[0];
                string[] animalInfo = commands[1].Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (command == "Add")
                {
                    Add(listOfAnimals, animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                }
                else if (command == "Feed")
                {
                    Feed(listOfAnimals, animalInfo[0], int.Parse(animalInfo[1]));
                }
            }

            Console.WriteLine($"Animals:");
            foreach (var animal in listOfAnimals)
            {
                Console.WriteLine($"{animal.Name} -> {animal.foodNeeded}g");
            }

            Console.WriteLine("Areas with hungry animals:");
            var animalAreas = new Dictionary<string, int>();
            foreach (var animal in listOfAnimals)
            {
                if (!animalAreas.ContainsKey(animal.Area))
                {
                    animalAreas.Add(animal.Area, 1);
                }
                else
                {
                    animalAreas[animal.Area]++;
                }
                
            }

            foreach (var area in animalAreas)
            {
                Console.WriteLine($"{area.Key} - {area.Value}");
            }
            
            


        }

        private static void Feed(List<Animal> listOfAnimals, string animalName, int foodToFeed)
        {
            foreach (var animal in listOfAnimals)
            {
                if (animal.Name == animalName)
                {
                    animal.foodNeeded -= foodToFeed;
                    if (animal.foodNeeded <= 0)
                    {
                        Console.WriteLine($"{animal.Name} was successfully fed");
                        listOfAnimals.Remove(animal);
                        return;
                    }

                }
            }
        }

        private static void Add(List<Animal> listOfAnimals, string animalName, int food, string area)
        {


            Animal newAnimal = new Animal();
            newAnimal.Name = animalName;
            newAnimal.foodNeeded = food;
            newAnimal.Area = area;

            foreach (var animal in listOfAnimals)
            {
                if (animal.Name == animalName)
                {
                    animal.foodNeeded += food;
                    return;
                }
                
            }

            listOfAnimals.Add(newAnimal);

        }
    }

    class Animal
    {
        public string Name { get; set; }
        public int foodNeeded { get; set; }
        public string Area { get; set; }
        


    }
}
