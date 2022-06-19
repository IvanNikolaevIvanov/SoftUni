using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            var list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            var listResult = new List<int>();
            int longerList = Math.Max(list1.Count, list2.Count);

            for (int i = 0; i < longerList; i++)
            {
                if (list1.Count > i)
                {
                    listResult.Add(list1[i]);
                }
                if (list2.Count > i)
                {
                    listResult.Add(list2[i]);
                }
                

                    
            }
            
            Console.WriteLine(string.Join(" ", listResult));
        }
    }
}
