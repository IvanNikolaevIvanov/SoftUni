﻿using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());

            string operation = Console.ReadLine();

            int secondNum = int.Parse(Console.ReadLine());

            double result = Calculation(firstNum, operation, secondNum);

            Console.WriteLine(result);

            static double Calculation(int firstNum, string operation, int secondNum)
            {
                double result = 0;

                switch (operation)
                {
                    case "/":
                        result = firstNum / secondNum;
                        break;
                    case "*":
                        result = firstNum * secondNum;
                        break;
                    case "+":
                        result = firstNum + secondNum;
                        break;
                    case "-":
                        result = firstNum - secondNum;
                        break;
                }

                return result;
            }
        }
    }
}
