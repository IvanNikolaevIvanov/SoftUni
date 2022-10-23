using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string inputNames = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matchedNames = regex.Matches(inputNames);

            Console.WriteLine(string.Join(" ", matchedNames));

           
        }
    }
}
