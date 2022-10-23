using System;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length - 1; i++)
            {
                char curChar = input[i];
                char secondChar = input[i + 1];
                if (curChar == secondChar)
                {
                    input = input.Remove(i + 1, 1);
                    i--;
                }

                
            }

            Console.WriteLine(input);
        }
    }
}
