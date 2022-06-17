using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int evenSum = GetSumOfEvenDigits(number);

            int oddSum = GetSumOfOddDigits(number);

            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);


            Console.WriteLine(result);


            
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sumofEvens = 0;
            int digits = number;

            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 == 0)
                {
                    sumofEvens += currentDigit;
                }

                digits /= 10;
            }

            return sumofEvens;
        }
        static int GetSumOfOddDigits(int number)
        {
            int sumofOdds = 0;
            int digits = number;

            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 != 0)
                {
                    sumofOdds += currentDigit;
                }

                digits /= 10;
            }

            return sumofOdds;


        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;

        }

    }
}
