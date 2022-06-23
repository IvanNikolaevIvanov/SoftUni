using System;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfIntegers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "End")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    listOfIntegers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    int currNum = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (index < 0 || index > listOfIntegers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        listOfIntegers.Insert(index, currNum);
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index < 0 || index > listOfIntegers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        listOfIntegers.RemoveAt(index);
                    }
                }
                else if (command[0] == "Shift")
                {
                    if (command[1] == "left")
                    {
                        int timesToLoop = int.Parse(command[2]);

                        for (int i = 0; i < timesToLoop; i++)
                        {
                            int firstIndex = listOfIntegers[0];
                            listOfIntegers.Add(firstIndex);
                            listOfIntegers.RemoveAt(0);
                        }
                    }
                    else if (command[1] == "right")
                    {
                        int timesToLoop = int.Parse(command[2]);

                        for (int i = 0; i < timesToLoop; i++)
                        {
                            int lastIndex = listOfIntegers[listOfIntegers.Count - 1];
                            listOfIntegers.RemoveAt(listOfIntegers.Count - 1);
                            listOfIntegers.Insert(0, lastIndex);
                            
                        }
                    }
                }


            }

            Console.WriteLine(string.Join(" ", listOfIntegers));
        }
    }
}
