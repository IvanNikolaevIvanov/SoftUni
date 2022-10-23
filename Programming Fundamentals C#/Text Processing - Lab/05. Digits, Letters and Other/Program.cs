using System;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digits = "";
            string letters = "";
            string others = "";

            for (int i = 0; i < input.Length; i++)
            {
                char currSymbol = input[i];

                if (char.IsDigit(currSymbol))
                {
                    digits += currSymbol;
                }
                else if (char.IsLetter(currSymbol))
                {
                    letters += currSymbol;
                }
                else
                {
                    others += currSymbol;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
