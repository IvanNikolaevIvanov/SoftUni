using System;

namespace Methods___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            
            SmallestOfThree(num1, num2, num3);
            
        }

        static void SmallestOfThree(int num1, int num2, int num3)
        {
            if (num1 < Math.Min(num2, num3))
            {
                Console.WriteLine(num1);
            }
            else
            {
                Console.WriteLine(Math.Min(num2, num3));
            }
        
        }
    }
}
