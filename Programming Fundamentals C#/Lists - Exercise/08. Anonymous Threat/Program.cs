using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                var commands = Console.ReadLine().Split().ToArray();

                if (commands[0] == "3:1")
                {
                    break;
                }

                string command = commands[0];

                int startIndex = int.Parse(commands[1]);
                int endIndex = int.Parse(commands[2]);

                if (startIndex > input.Count - 1 || startIndex < 0)
                {
                    startIndex = 0;
                }
                if (endIndex > input.Count - 1 || endIndex < 0)
                {
                    endIndex = input.Count - 1;
                }

                if (command == "merge")
                {
                    string mergedWord = string.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        mergedWord += input[i];
                    }

                    input.RemoveRange(startIndex, endIndex - startIndex + 1);
                    input.Insert(startIndex, mergedWord);
                }
                else if (command == "divide")
                {
                    int partitions = int.Parse(commands[2]);
                    string wordToDivide = input[startIndex];
                    var divisionList = new List<string>();

                    int parts = wordToDivide.Length / partitions;

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            divisionList.Add(wordToDivide.Substring(i * parts));
                        }
                        else
                        {
                            divisionList.Add(wordToDivide.Substring(i * parts, parts));
                        }
                    }
                    input.RemoveAt(startIndex);
                    input.InsertRange(startIndex, divisionList);
                }
            }

            Console.WriteLine(string.Join(" ", input));

        }
    }
}

