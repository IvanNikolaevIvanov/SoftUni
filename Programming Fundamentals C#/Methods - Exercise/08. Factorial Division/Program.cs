using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double factoriel1 = FindFactoriel(num1);
            double factoriel2 = FindFactoriel(num2);
            Console.WriteLine($"{factoriel1 / factoriel2:f2}"); 
            
        }

        private static double FindFactoriel(double num)
        {
            double factoral = 1;

            while (num != 1)
            {
                factoral *= num;
                num--;
            }
            return factoral;
        }
    }
}
