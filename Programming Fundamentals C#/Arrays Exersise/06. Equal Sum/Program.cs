using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr.Length == 0)
                {
                    Console.WriteLine(0);
                    return;
                }

                leftSum = 0;

                for (int sumLeft = i; sumLeft > 0; sumLeft--)
                {
                    int nextLElement = sumLeft - 1;
                    if (sumLeft > 0)
                    {
                        leftSum += arr[nextLElement];
                    }
                }

                rightSum = 0;

                for (int sumRight = i; sumRight < arr.Length; sumRight++)
                {
                    int nextRElement = sumRight + 1;
                    if (sumRight < arr.Length - 1)
                    {
                        rightSum += arr[nextRElement];
                    }

                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                    
                }

            }
            Console.WriteLine("no");


        }
    }
}
