using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> listOfGuests = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[2] == "going!")
                {
                    if (listOfGuests.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                    else
                    {
                        listOfGuests.Add(command[0]);
                    }
                                       
                }
                if (command[2] == "not")
                {
                    if (listOfGuests.Contains(command[0]))
                    {
                        listOfGuests.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }

                }

            }

            foreach (var name in listOfGuests)
            {
                Console.WriteLine(name);
            }
        }
    }
}
