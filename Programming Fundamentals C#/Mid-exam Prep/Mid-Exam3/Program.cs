using System;
using System.Linq;

namespace Mid_Exam3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int entryPointIndex = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int leftSum = 0;
            int rightSum = 0;


            if (command == "cheap")
            {


                for (int i = entryPointIndex; i >= 0; i--)
                {
                    if (list[i] < list[entryPointIndex])
                    {
                        leftSum += list[i];
                    }
                }

                for (int i = entryPointIndex; i <= list.Count - 1; i++)
                {
                    if (list[i] < list[entryPointIndex])
                    {
                        rightSum += list[i];
                    }

                }

                if (leftSum > rightSum)
                {
                    Console.WriteLine($"Left - {leftSum}");
                }
                else if (rightSum > leftSum)
                {
                    Console.WriteLine($"Right - {rightSum}");
                }
                else if (leftSum == rightSum)
                {
                    Console.WriteLine($"Left - {leftSum}");
                }

            }

            if (command == "expensive")
            {


                for (int i = entryPointIndex - 1; i >= 0; i--)
                {
                    if (list[i] >= list[entryPointIndex])
                    {
                        leftSum += list[i];
                    }
                }

                for (int i = entryPointIndex + 1; i <= list.Count - 1; i++)
                {
                    if (list[i] >= list[entryPointIndex])
                    {
                        rightSum += list[i];
                    }

                }

                if (leftSum > rightSum)
                {
                    Console.WriteLine($"Left - {leftSum}");
                }
                else if (rightSum > leftSum)
                {
                    Console.WriteLine($"Right - {rightSum}");
                }
                else if (leftSum == rightSum)
                {
                    Console.WriteLine($"Left - {leftSum}");
                }

            }
        }
    }
}
