using System;
using System.Text.RegularExpressions;

namespace _2._3_Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([\||#])(?<name>[A-Za-z\s]+)\1(?<date>[\d]{2}\/[\d]{2}\/\d{2})\1(?<cals>[\d]+)\1";

            int totalCals = 0;

            MatchCollection foodMatches = Regex.Matches(input, pattern);
            foreach (Match food in foodMatches)
            {
                totalCals += int.Parse(food.Groups["cals"].Value);
            }


            Console.WriteLine($"You have food to last you for: {totalCals / 2000} days!");
            
            foreach (Match food in foodMatches)
            {
                string name = food.Groups["name"].Value;
                string date = food.Groups["date"].Value;
                string cals = food.Groups["cals"].Value;

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {cals}");
            }

        }
    }
}
