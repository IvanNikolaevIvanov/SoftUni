using System;
using System.Collections.Generic;

namespace _03._Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, double> productsPrices = new Dictionary<string, double>();
            Dictionary<string, int> productsQuantity = new Dictionary<string, int>();

            

            while (true)
            {
                string[] product = Console.ReadLine().Split();
                if (product[0] == "buy")
                {
                    break;
                }

                string productName = product[0];
                double price = double.Parse(product[1]);
                int quantity = int.Parse(product[2]);
                

                if (!productsPrices.ContainsKey(productName))
                {
                    productsPrices.Add(productName, price);
                    productsQuantity.Add(productName, quantity);
                }
                else if (productsPrices.ContainsKey(productName))
                {
                    productsPrices.Remove(productName);
                    productsPrices.Add(productName, price);
                    productsQuantity[productName] += quantity;
                }
                

            }

            foreach (var item in productsPrices)
            {
                foreach (var newitem in productsQuantity)
                {
                    if (item.Key == newitem.Key)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value * newitem.Value:f2}");
                    }
                }
            }
        }
    }
}
