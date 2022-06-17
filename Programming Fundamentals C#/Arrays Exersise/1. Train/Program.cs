using System;
using System.Linq;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] peoplePerWagon = new int[wagons];

            int totalSum = 0;

            

            for (int i = 0; i < wagons; i++)
            {
               peoplePerWagon[i] = int.Parse(Console.ReadLine());

                totalSum += peoplePerWagon[i];

                
            }

            for (int i = 0; i < peoplePerWagon.Length; i++)
            {
                Console.Write($"{peoplePerWagon[i] } ");
            }

            Console.WriteLine();
            Console.WriteLine(totalSum);
           
        }
    }
}
