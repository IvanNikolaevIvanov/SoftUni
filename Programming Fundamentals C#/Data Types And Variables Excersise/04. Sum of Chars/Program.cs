using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int sumOfChars = 0;


            for (int i = 1; i <= n; i++)
            {
                char ch = char.Parse(Console.ReadLine());

                int currentNum = (int)ch;

                sumOfChars += currentNum;
            }
            Console.WriteLine($"The sum equals: {sumOfChars}");

        }
    }
}
