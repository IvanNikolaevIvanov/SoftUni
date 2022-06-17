using System;
using System.Linq;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            NumberOfVowels(input);
        }

        private static void NumberOfVowels(string input)
        {
            int count = 0;

            foreach (char vowel in input)
            {
                if ("aouei".Contains(vowel))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
