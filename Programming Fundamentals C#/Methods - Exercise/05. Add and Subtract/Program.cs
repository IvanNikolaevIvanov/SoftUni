using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = SumOFFirstAndSecondNum(num1, num2);

            int subtraction = SubtractsThirdNumFromSum(sum, num3);

            Console.WriteLine(subtraction);
        }

        private static int SubtractsThirdNumFromSum(int sum, int num3)
        {
            return sum - num3;
        }

        private static int SumOFFirstAndSecondNum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
