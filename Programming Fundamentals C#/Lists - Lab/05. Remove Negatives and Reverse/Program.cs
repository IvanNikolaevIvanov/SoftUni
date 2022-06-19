using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfIntegers = Console.ReadLine().Split().Select(int.Parse).ToList();
            

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                int currentNum = listOfIntegers[i];
                if (currentNum < 0)
                {
                    listOfIntegers.RemoveAt(i);
                    i = -1;
                }
                

                if (listOfIntegers.Count == 0)
                {
                    Console.WriteLine("empty");
                    return;
                }
            }
            listOfIntegers.Reverse();

            Console.WriteLine(string.Join(" ", listOfIntegers));
        }
    }
}
