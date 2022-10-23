using System;
using System.Linq;

namespace _03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int index1 = 0;
            int index2 = 0;
            int movesCounter = 0;
            string currentElement1 = string.Empty;
            string currentElement2 = string.Empty;

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "end")
                {
                    break;
                }

                if (list.Count <= 0)
                {
                    continue;
                }

                movesCounter++;

                index1 = int.Parse(input[0]);
                index2 = int.Parse(input[1]);

                if (index1 == index2 || index1 < 0 || index2 < 0 || index1 > list.Count - 1 || index2 > list.Count - 1)
                {
                    list.Insert(list.Count / 2, $"-{movesCounter}a");
                    list.Insert(list.Count / 2, $"-{movesCounter}a");

                    Console.WriteLine($"Invalid input! Adding additional elements to the board");

                    continue;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    
                    if (index1 == i)
                    {
                        currentElement1 = list[i];
                    }
                    if (index2 == i)
                    {
                        currentElement2 = list[i];
                    }
                }
                if (currentElement1 == currentElement2)
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {list[index1]}!");

                    list.Remove(currentElement1);
                    list.Remove(currentElement2);

                }
                else if (currentElement1 != currentElement2)
                {
                    Console.WriteLine("Try again!");
                }

                if (list.Count <= 0)
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    
                }

            }

            if (list.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}
