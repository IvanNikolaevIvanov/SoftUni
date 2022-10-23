using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleOnQue = int.Parse(Console.ReadLine());

            var wagons = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int maxPeopleOnWagon = 4;
            int fullWagonsCounter = 0;

            for (int i = 0; i < wagons.Count; i++)
            {
                while (wagons[i] < maxPeopleOnWagon)
                {
                    wagons[i]++;
                    peopleOnQue--;

                    if (peopleOnQue <= 0)
                    {
                        foreach (var wagon in wagons)
                        {
                            if (wagon == maxPeopleOnWagon)
                            {
                                fullWagonsCounter++;
                            }
                            if (fullWagonsCounter == wagons.Count)
                            {
                                Console.WriteLine(string.Join(' ', wagons));
                                return;
                            }
                        }

                        Console.WriteLine($"The lift has empty spots!");
                        Console.WriteLine(string.Join(' ', wagons));
                        return;
                    }
                }

                
            }

            Console.WriteLine($"There isn't enough space! {peopleOnQue} people in a queue!");
            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
