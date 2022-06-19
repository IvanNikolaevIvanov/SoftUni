using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isListChanged = false;

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    list.Add(int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    list.Remove(int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    list.RemoveAt(int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isListChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    if (list.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }

                }
                else if (command[0] == "PrintEven")
                {
                    PrintEven(list);
                }
                else if (command[0] == "PrintOdd")
                {
                    PrintOdd(list);
                }
                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(list.Sum());

                }
                else if (command[0] == "Filter")
                {
                    Filter(command[1], int.Parse(command[2]), list);
                }


            }

            if (isListChanged == true)
            {
                Console.WriteLine(string.Join(" ", list));
            }
            
        }

        private static void PrintOdd(List<int> list)
        {
            foreach (var number in list)
            {
                if (number % 2 != 0)
                {
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintEven(List<int> list)
        {
            foreach (var number in list)
            {
                if (number % 2 == 0)
                {
                    Console.Write($"{number} ");
                }
            }
            Console.WriteLine();
        }

        private static void Filter(string filter, int numberToFilter, List<int> list)
        {
            switch (filter)
            {
                case "<":
                    foreach (var number in list)
                    {
                        if (number < numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }

                    }
                    break;
                case "<=":
                    foreach (var number in list)
                    {
                        if (number <= numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }

                    }
                    break;
                case ">":
                    foreach (var number in list)
                    {
                        if (number > numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }

                    }
                    break;
                case ">=":
                    foreach (var number in list)
                    {
                        if (number >= numberToFilter)
                        {
                            Console.Write($"{number} ");
                        }

                    }
                    break;
            }
            Console.WriteLine();
        }
    }
}

