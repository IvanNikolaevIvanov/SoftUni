using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._2_Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string wordsPattern = @"(?<separator>[@|#])(?<first>[A-Za-z]{3,})\k<separator>{2}(?<second>[A-Za-z]{3,})\k<separator>";

            string mirrorPair = "";

            var mirrorPairList = new List<string>();

            MatchCollection matches = Regex.Matches(text, wordsPattern);
            
            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine($"No word pairs found!");
            }

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["first"].Value;
                string secondWord = match.Groups["second"].Value;
                string secondRevWord = "";
                for (int i = secondWord.Length - 1; i >= 0; i--)
                {
                    secondRevWord += secondWord[i];
                }
                if (firstWord == secondRevWord)
                {
                    mirrorPair = $"{firstWord} <=> {secondWord}";
                    mirrorPairList.Add(mirrorPair);
                }

                
            }


            if (mirrorPairList.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", mirrorPairList));
            }
            else
            {
                Console.WriteLine($"No mirror words!");
            }
            

        }
    }
}
