using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@(?<name>[A-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<type>[A|D])![^@\-!:>]*->(?<count>[\d]+)";

            int n = int.Parse(Console.ReadLine());

            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int key = input.ToLower().Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');

                string decryptedInput = "";

                foreach (var character in input)
                {
                    decryptedInput += (char)(character - key);
                }

                Match match = Regex.Match(decryptedInput, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].ToString();
                    int population = int.Parse(match.Groups["population"].Value);
                    char type = char.Parse(match.Groups["type"].Value);
                    int count = int.Parse(match.Groups["count"].Value);

                    if (type == 'A')
                    {
                        attackedPlanets.Add(name);
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                    }
                }

                
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            var orderedAttackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
            foreach (var planet in orderedAttackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.OrderBy(x => x).ToList()
                .ForEach(planet => Console.WriteLine($"-> {planet}"));
            

          
        }
    }
}
