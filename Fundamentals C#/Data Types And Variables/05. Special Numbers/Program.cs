using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());



            for (int i = 1; i <= n; i++)
            {
                int currentNum = i;
                double sumOfDigits = 0;
                while (currentNum > 0)
                {
                    sumOfDigits += currentNum % 10;
                    currentNum = currentNum / 10;
                }
                



                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }


                
            }
        }
    }
}
