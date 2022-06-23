using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
             

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "Delete")
                {
                    DeleteElement(int.Parse(command[1]), numbers);
                }

                if (command[0] == "Insert")
                {
                    InsertElementAtPosition(int.Parse(command[1]), int.Parse(command[2]), numbers);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
        
        
        

         static string DeleteElement(int element, List<int> numbers)
        {
            numbers.RemoveAll(number => number == element);
            return numbers.ToString();
            
        }

        static string InsertElementAtPosition(int element, int position, List<int> numbers)
        {
            numbers.Insert(position, element);
            return numbers.ToString();

        }
    }
}
