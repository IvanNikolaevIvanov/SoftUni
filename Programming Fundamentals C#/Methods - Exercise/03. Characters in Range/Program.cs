using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            PrintCharsBetweenChars(char1, char2);
        }

        private static void PrintCharsBetweenChars(char char1, char char2)
        {
            int start = Math.Min(char1, char2);
            int end = Math.Max(char1, char2);
            for (int i = start + 1; i < end; i++)
            {
                Console.Write($"{(char)i} ");
            }

        }
    }
}
