using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;

            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (capacity < input)
                {
                    Console.WriteLine($"Insufficient capacity!");
                    continue;
                }
                else
                {
                    capacity -= input;
                    sum += input;
                }

                
            }

            Console.WriteLine(sum);
        }
    }
}
