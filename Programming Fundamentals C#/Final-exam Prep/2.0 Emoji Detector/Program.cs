using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._0_Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string digitPattern = @"[\d]";
            string emojiPattern = @"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";

            string input = Console.ReadLine();

            double treshold = 1;

            MatchCollection digitMatches = Regex.Matches(input, digitPattern);
            foreach (Match match in digitMatches)
            {
                treshold *= int.Parse(match.ToString());
            }

            MatchCollection emojiMatches = Regex.Matches(input, emojiPattern);

            Console.WriteLine($"Cool threshold: {treshold}");

            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

            foreach (Match emojiMatch in emojiMatches)
            {
                //string emoji = emojiMatch.Groups["emoji"].Value;
                //double emojiCoolness = emoji.ToCharArray().Sum(x => x);

                //if (emojiCoolness >= treshold)
                //{
                //    Console.WriteLine(emojiMatch.Value);
                //}
                string currentEmoji = emojiMatch.Groups["emoji"].Value;
                long emojiCoolnes = 0;

                for (int i = 0; i < currentEmoji.Length; i++)
                {
                    char curSymbol = currentEmoji[i];
                    emojiCoolnes += curSymbol;
                }

                if (emojiCoolnes >= treshold)
                {
                    Console.WriteLine(emojiMatch.Value);
                }
            }

        }
    }
}
