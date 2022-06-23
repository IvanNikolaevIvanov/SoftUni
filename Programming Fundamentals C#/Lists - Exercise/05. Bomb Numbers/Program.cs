using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

            var bombNumAndPow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bomba = bombNumAndPow[0];
            int power = bombNumAndPow[1];

            //    for (int i = 0; i < listOfNumbers.Count; i++)
            //    {
            //        if (listOfNumbers[i] == bomba)
            //        {
            //            BombNumbers(power, i, listOfNumbers);
            //        }
            //    }

            //    Console.WriteLine(listOfNumbers.Sum());
            //}

            //private static void BombNumbers(int power, int index, List<int> listOfNumbers)
            //{
            //    int start = Math.Max(0, (index - power));
            //    int end = Math.Min(listOfNumbers.Count - 1, (index + power));

            //    for (int i = start; i <= end; i++)
            //    {
            //        listOfNumbers[i] = 0;
            //    }
            //}
            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (listOfNumbers[i] == bomba)
                {
                    int startIndex = i - power;
                    
                    if (startIndex >= 0)
                    {
                        if (startIndex + (power * 2 + 1) > listOfNumbers.Count - 1)
                        {
                            int indexesToRemove = 0;
                            for (int j = startIndex; j < listOfNumbers.Count; j++)
                            {
                                indexesToRemove++;
                            }

                            listOfNumbers.RemoveRange(startIndex, indexesToRemove);
                        }
                        else
                        {
                            listOfNumbers.RemoveRange(startIndex, power * 2 + 1);
                        }

                        
                    }
                    else
                    {
                        startIndex = 0;
                        if (startIndex + i + power < listOfNumbers.Count)
                        {

                            int indexesToRemove = 0;
                            for (int z = 0; z <= (i + power); z++)
                            {
                                indexesToRemove++;
                            }

                            listOfNumbers.RemoveRange(startIndex, indexesToRemove);
                        }
                        else
                        {
                            Console.WriteLine("0");
                            return;
                        }




                    }
                    i--;

                }
            }

            //Console.WriteLine(string.Join(' ', listOfNumbers));
            Console.WriteLine(listOfNumbers.Sum());

        }


    }
}
