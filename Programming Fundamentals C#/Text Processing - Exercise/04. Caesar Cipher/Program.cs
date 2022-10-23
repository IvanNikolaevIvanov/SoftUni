using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder(); 

            for (int i = 0; i < input.Length; i++)
            {
                char curChar = input[i];
                int encrChar = curChar + 3;
                char newChar = (char)encrChar;

                sb.Append(newChar);
            }

            Console.WriteLine(sb);
        }
    }
}
