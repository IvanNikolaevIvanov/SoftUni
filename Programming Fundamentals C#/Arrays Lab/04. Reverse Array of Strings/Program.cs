using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < elements.Length / 2; i++)
            {
                var oldElelment = elements[i];
                elements[i] = elements[elements.Length - 1 - i];

                elements[elements.Length - 1 - i] = oldElelment;

            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
