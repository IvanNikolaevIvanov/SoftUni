using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNum = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            if (secondNum == 0)
            {
                Console.WriteLine("0");
                return;
            }

            StringBuilder sb = new StringBuilder();

            int reminder = 0;

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                char curChar = firstNum[i];

                int curDigit = int.Parse(curChar.ToString());

                int result = curDigit * secondNum + reminder;

                sb.Append(result % 10);

                reminder = result / 10;

            }

            if (reminder != 0)
            {
                sb.Append(reminder);
            }

            StringBuilder reversedSB = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                reversedSB.Append(sb[i]);
            }
            
            Console.WriteLine(reversedSB);
        }
    }
}
