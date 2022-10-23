using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[\d]+.?[\d]+?)\$";

            //customer, product, count and price.

            string currCustomer = "";
            string currProduct = "";
            int count = 0;
            double price = 0;
            double totalPrice = count * price;
            double income = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    //double price = double.Parse(match.Groups["price"].Value);
                    currCustomer = match.Groups["name"].ToString();
                    currProduct = match.Groups["product"].Value;
                    count = int.Parse(match.Groups["count"].Value);
                    price = double.Parse(match.Groups["price"].Value);
                    totalPrice = count * price;

                    income += totalPrice;

                    Console.WriteLine($"{currCustomer}: {currProduct} - {totalPrice:f2}");
                }

             

                


                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
