using System;
using System.Linq;

namespace _033._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int startIndex = 0;
            int currIndex = 0;
            while (true)
            {
                var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commands[0] == "Love!") { break; }

                int jumpLength = int.Parse(commands[1]);



                currIndex = startIndex + jumpLength;
                if (currIndex > list.Count - 1)
                {
                    currIndex = 0;
                }

                if (currIndex >= 0 && currIndex <= list.Count - 1)
                {
                    if (list[currIndex] == 0)
                    {
                        Console.WriteLine($"Place {currIndex} already had Valentine's day.");

                    }
                    else
                    {
                        list[currIndex] -= 2;
                        if (list[currIndex] == 0)
                        {
                            Console.WriteLine($"Place {currIndex} has Valentine's day.");

                        }
                    }

                }

                startIndex = currIndex;

            }

            Console.WriteLine($"Cupid's last position was {currIndex}.");
            if (list.Sum() == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                int counter = 0;

                for (int i = 0; i < list.Count; i++)
               
                {
                    if (list[i] > 0)
                    {
                        counter++;
                    }
                }

                Console.WriteLine($"Cupid has failed {counter} places.");

            }
        }
    }
}

