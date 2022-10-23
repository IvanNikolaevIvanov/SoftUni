using System;

namespace Mid_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());

            string nameOfCity = string.Empty;
            double income = 0;
            double expences = 0;
            double currentProfit = 0;
            double totalExpences = 0;
            double totalIncome = 0;
            double totalProfit = 0;

            for (int i = 1; i <= numberOfCities; i++)
            {
                nameOfCity = Console.ReadLine();
                income = double.Parse(Console.ReadLine());
                expences = double.Parse(Console.ReadLine());

                if (i % 3 == 0 && i % 5 != 0)
                {
                    expences += expences * 0.5;
                }

                if (i % 5 == 0)
                {
                    income -= income * 0.1;
                }

                currentProfit = income - expences;

                totalProfit += currentProfit;

                Console.WriteLine($"In {nameOfCity} Burger Bus earned {currentProfit:f2} leva.");

            }

            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
