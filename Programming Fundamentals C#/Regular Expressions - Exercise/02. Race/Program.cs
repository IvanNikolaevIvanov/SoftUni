using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfParticipants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string patternForName = @"(?<name>[A-Za-z]+)";
            string patternForDigits = @"(?<number>\d+)";

            int sumOfDigits = 0;

            var racers = new Dictionary<string, int>();

            while (true)
            {
                string information = Console.ReadLine();
                if (information == "end of race")
                {
                    break;
                }

                MatchCollection matchName = Regex.Matches(information, patternForName);
                MatchCollection matchDigits = Regex.Matches(information, patternForDigits);

                string currentName = string.Join("", matchName);
                string currentDistance = string.Join("", matchDigits);

                sumOfDigits = 0;

                for (int i = 0; i < currentDistance.Length; i++)
                {
                    sumOfDigits += int.Parse(currentDistance[i].ToString());
                }

                if (listOfParticipants.Contains(currentName))
                {
                    if (!racers.ContainsKey(currentName))
                    {
                        racers.Add(currentName, sumOfDigits);
                    }
                    else
                    {
                        racers[currentName] += sumOfDigits;
                    }
                    
                }
            }

            var winners = racers.OrderByDescending(x => x.Value).Take(3);



            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2)
                .OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var name in firstPlace)
            {
                Console.WriteLine($"1st place: {name.Key}");
            }
            foreach (var name in secondPlace)
            {
                Console.WriteLine($"2nd place: {name.Key}");
            }
            foreach (var name in thirdPlace)
            {
                Console.WriteLine($"3rd place: {name.Key}");
            }
        }
    }
}
