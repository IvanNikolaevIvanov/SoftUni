using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string productName = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            PrintPrice(productName, quantity);

        }

        private static void PrintPrice(string productName, double quantity)
        {
            //•	coffee – 1.50
            //•	water – 1.00
            //•	coke – 1.40
            //•	snacks – 2.00

            if (productName == "coffee" )
            {
                Console.WriteLine($"{quantity * 1.50:f2}"); 
            }
            else if (productName == "water")
            {
                Console.WriteLine($"{quantity * 1.00:f2}");
            }
            else if (productName == "coke")
            {
                Console.WriteLine($"{quantity * 1.40:f2}");
            }
            else if (productName == "snacks")
            {
                Console.WriteLine($"{quantity * 2.00:f2}");
            }
        }
    }
}
