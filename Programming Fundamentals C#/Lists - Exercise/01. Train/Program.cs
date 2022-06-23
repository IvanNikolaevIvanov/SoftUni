using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else if (command[0] != "Add")
                {
                    int addPeople = int.Parse(command[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (maxCapacity - wagons[i] >= addPeople )
                        {
                            wagons[i] += addPeople;
                            break;
                        }
                    }
                }


            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
