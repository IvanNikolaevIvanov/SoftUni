using System;
using System.Linq;

namespace _031._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string command = string.Empty;
            int index = 0;
            int currentIndex = 0;

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (commands[0] == "End")
                {
                    break;
                }

                command = commands[0];
                index = int.Parse(commands[1]);

                if (command == "Shoot")
                {
                    int power = int.Parse(commands[2]);

                    if (index < 0 || index > list.Count - 1) { continue; }

                        for (int i = 0; i < list.Count; i++)
                    {
                        if (i == index)
                        {
                            currentIndex = i;

                            list[currentIndex] -= power;
                            if (list[currentIndex] <= 0)
                            {
                                list.RemoveAt(currentIndex);
                            }
                            break;
                        }
                    }

                    
                }
                else if (command == "Add")
                {
                    int value = int.Parse(commands[2]);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == index)
                        {
                            currentIndex = i;
                            list.Insert(currentIndex, value);
                            break;
                        }
                        
                    }

                    if (index < 0 || index > list.Count - 1)
                    {
                        Console.WriteLine("Invalid placement!");
                    }

                }
                else if (command == "Strike")
                {
                    int radius = int.Parse(commands[2]);                   
                    int currTarget = 0;
                    int startIndex = 0;
                    int endIndex = 0;

                    if (index > 0 && index <= list.Count - 1)
                    {
                        currTarget = index;
                    }

                    startIndex = currTarget - radius;
                    endIndex = currTarget + radius;

                    if (startIndex < 0 || startIndex > list.Count - 1 || endIndex < 0  || endIndex > list.Count - 1 )
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        list.RemoveRange(startIndex, ((radius * 2) + 1));
                    }





                }

            }
            Console.WriteLine(string.Join('|', list));
        }
    }
}
