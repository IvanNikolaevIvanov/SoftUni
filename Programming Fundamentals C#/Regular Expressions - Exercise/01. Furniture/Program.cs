using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            var listOfProducts = new List<string>();

            double totalPrice = 0;

            while (input != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    double price = double.Parse(match.Groups["price"].Value);

                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    listOfProducts.Add(match.Groups["name"].ToString());

                    totalPrice += price * quantity;
                }

                

                input = Console.ReadLine();

            }

            Console.WriteLine($"Bought furniture:");
            foreach (var product in listOfProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
