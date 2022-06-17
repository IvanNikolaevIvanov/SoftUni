using System;
using System.Numerics;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());


            for (int i = 16; i <= end; i++)
            {
                int currentNum = i;
                
                bool NumIsTopNumber = false;

                CheckIfSumOfDigitsDividesByEight(NumIsTopNumber, currentNum);
                CheckIfAnyOfDigitsIsOdd(NumIsTopNumber, currentNum);

                if (CheckIfAnyOfDigitsIsOdd(NumIsTopNumber, currentNum) == true && CheckIfSumOfDigitsDividesByEight(NumIsTopNumber, currentNum) == true )
                {
                    Console.WriteLine($"{currentNum}");
                }

            }
            
        }

        

        private static bool CheckIfSumOfDigitsDividesByEight(bool numIsTopNumber, int currentNum)
        {
            int sumOfDigits = 0;
            while (currentNum > 0)
            {
                sumOfDigits += currentNum % 10;
                currentNum /= 10;
            }
            if (sumOfDigits % 8 == 0)
            {
                return true;

            }
            return false;
        }

        private static bool CheckIfAnyOfDigitsIsOdd(bool numIsTopNumber, int currentNum)
        {
            int currentDigit = 0;
            while (currentNum > 0)
            {
                currentDigit = currentNum % 10;
                if (currentDigit % 2 != 0)
                {
                    return true;
                    
                }

                currentNum /= 10;
            }

            return false;
        }
    }
}
