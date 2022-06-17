using System;

namespace _1._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());

            int firstOp = num1 + num2;
            int secondOp = firstOp  / num3;
            int thirdOp = secondOp * num4;
            
            Console.WriteLine(thirdOp);


        }
    }
}
