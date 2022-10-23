using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>[\d]{2})(?<separator>[.\/\-])(?<month>[A-Z]{1}[a-z]{2})\k<separator>(?<year>[\d]{4})\b";

            string dates = Console.ReadLine();

            MatchCollection matches = Regex.Matches(dates, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
