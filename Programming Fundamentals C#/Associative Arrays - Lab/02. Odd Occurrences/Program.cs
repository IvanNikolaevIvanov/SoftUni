using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Dictionary<string, int> oddNUmberOfWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string currWord = word.ToLower();

                if (!oddNUmberOfWords.ContainsKey(currWord))
                {
                    oddNUmberOfWords.Add(currWord, 0);
                }

                oddNUmberOfWords[currWord]++;
            }

            foreach (var word in oddNUmberOfWords)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
