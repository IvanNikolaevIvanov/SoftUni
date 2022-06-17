using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                       
            bool isSpecialNum = false;

            for (int i = 1; i <= n; i++)

            {
                int sum = 0;
                int currentNum = i;

                while (currentNum > 0)

                {

                    sum += currentNum % 10;

                    currentNum = currentNum / 10;

                }

                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine("{0} -> {1}", i, isSpecialNum);

               

            }
        }
    }
}
