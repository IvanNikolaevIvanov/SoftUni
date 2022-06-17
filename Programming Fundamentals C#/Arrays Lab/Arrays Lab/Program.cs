using System;

namespace Arrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Ivan", "kirka", "bread" };

            foreach (var word in words)
            {
                Console.Write($"{word}////");
            }
        }
    }
}
