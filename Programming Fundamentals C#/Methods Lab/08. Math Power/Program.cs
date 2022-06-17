using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double result = NumberOnPower(num1, num2);
            Console.WriteLine(result);

        }

        private static double NumberOnPower(double num1, double num2)
        {
            double result = 1;
            for (int i = 0; i < num2; i++)
            {
                result *= num1;
            }

            return result;
        }
    }
}
