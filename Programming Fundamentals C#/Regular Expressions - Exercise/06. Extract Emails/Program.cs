﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|\s)[A-Za-z0-9][\w*\-\.]*[A-Za-z0-9]@[A-Za-z]+([.-][A-Za-z]+)+\b";

            string input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            //matches.ToList().ForEach(Console.WriteLine);
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }

        }
    }
}
