using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var listOfRemovedElements = new List<int>();
            int indexToRemove = 0;
            int currentValue = 0;

            while (list.Count > 0)
            {
                indexToRemove = int.Parse(Console.ReadLine());
                if (indexToRemove < 0)
                {
                    currentValue = list[0];
                    listOfRemovedElements.Add(currentValue);
                    list[0] = list[list.Count - 1];
                }
                else if (indexToRemove > list.Count - 1)
                {
                    currentValue = list[list.Count - 1];
                    listOfRemovedElements.Add(currentValue);
                    list[list.Count - 1] = list[0];
                }
                else
                {
                    currentValue = list[indexToRemove];
                    listOfRemovedElements.Add(currentValue);
                    list.RemoveAt(indexToRemove);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] <= currentValue)
                    {
                        list[i] += currentValue;
                    }
                    else
                    {
                        list[i] -= currentValue;
                    }
                }
                                
                //Console.WriteLine(string.Join(' ', list))                
            }
            Console.WriteLine(listOfRemovedElements.Sum());
        }
    }
}
