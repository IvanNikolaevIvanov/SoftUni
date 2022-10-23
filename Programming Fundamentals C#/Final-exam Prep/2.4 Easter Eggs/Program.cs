using System;
using System.Text.RegularExpressions;

namespace _2._4_Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"[@|#]+(?<color>[a-z]{3,})[@|#]+[^A-Za-z\d]*[\/]+(?<count>[\d]+)[\/]+";

            MatchCollection eggMatches = Regex.Matches(input, pattern);

            foreach (Match eggmatch in eggMatches)
            {
                string ammount = eggmatch.Groups["count"].Value;
                string color = eggmatch.Groups["color"].Value;
                
                Console.WriteLine($"You found {ammount} {color} eggs!");
            }
        }
    }
}
