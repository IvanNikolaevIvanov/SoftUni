using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string currentNum = command;
                Reverse(command);
                if (currentNum == Reverse(command))
                {
                    Console.WriteLine("true");

                }
                else
                {
                    Console.WriteLine("false");
                }

                command = Console.ReadLine();

            }
        }

        private static string Reverse(string command)
        {
            char[] charArr = command.ToCharArray();
            Array.Reverse(charArr);

            return new string(charArr);
        }
    }
}
