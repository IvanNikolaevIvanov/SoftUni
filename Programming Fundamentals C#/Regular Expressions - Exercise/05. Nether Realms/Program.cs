using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^0-9\+\-\*\/\.,]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplyDevidePattern = @"[\*\/]";
            string splitterPattern = @"[,\s]+";

            string input = Console.ReadLine();

            string[] demons = Regex.Split(input, splitterPattern).OrderBy(x => x).ToArray();

            for (int i = 0; i < demons.Length; i++)
            {
                string currentDemon = demons[i];

                var healthMatches = Regex.Matches(currentDemon, healthPattern);

                var health = 0;

                foreach (Match match in healthMatches)
                {
                    char currChar = char.Parse(match.ToString());
                    health += currChar;
                }

                double damage = 0;

                var damageMatches = Regex.Matches(currentDemon, damagePattern);

                foreach (Match match in damageMatches)
                {
                    double currDamage = double.Parse(match.ToString());
                    damage += currDamage;

                }

                var multiplyAndDivide = Regex.Matches(currentDemon, multiplyDevidePattern);

                foreach (Match match in multiplyAndDivide)
                {
                    char currSymbol = char.Parse(match.ToString());

                    if (currSymbol == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {health} health, {damage:f2} damage");

            }

        }
    }
}
