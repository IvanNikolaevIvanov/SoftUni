using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, string>();

            while (true)
            {
                string word = Console.ReadLine();
                if (word == "end")
                {
                    break;
                }

                

                string reversedWord = string.Empty;

                var sb = new StringBuilder();

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    char curSymbol = word[i];
                    sb.Append(curSymbol);
                }

                reversedWord = sb.ToString();

                words.Add(word, reversedWord);

            }

            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            };
        }
    }
}
