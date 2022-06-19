using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var gaussNumbers = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int currentGaussNum = numbers[i] + numbers[numbers.Count - 1 - i];

                gaussNumbers.Add(currentGaussNum);
            }

            if (numbers.Count % 2 != 0)
            {
                gaussNumbers.Add(numbers[numbers.Count / 2]);
            }
            Console.WriteLine(string.Join(" ", gaussNumbers));

        }
    }
}
