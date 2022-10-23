using System;
using System.Text.RegularExpressions;

namespace _2._1_Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string barcodePattern = @"[@][#]+(?<name>[A-Z][A-Za-z\d]{4,}[A-Z])[@][#]+";

            string digitPattern = @"\d";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, barcodePattern);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    string barcode = match.Groups["name"].Value;
                    string productGroup = "";
                   
                    MatchCollection digitsCollection = Regex.Matches(barcode, digitPattern);
                    foreach (Match digit in digitsCollection)
                    {
                        productGroup += digit.ToString();
                    }

                    if (productGroup.Length > 0)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    
                }
            }
        }
    }
}
