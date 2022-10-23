using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Dictionary<char, int> ocurrences = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!ocurrences.ContainsKey(letter))
                    {
                        ocurrences.Add(letter, 0);
                    }

                    ocurrences[letter]++;
                }
            }

            foreach (var ocurrence in ocurrences)
            {
                Console.WriteLine($"{ocurrence.Key} -> {ocurrence.Value}");
            }

        }
    }
}
