using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int power = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char curSymbol = input[i];

                if (curSymbol == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                    sb.Append(curSymbol);
                }
                else if (power == 0)
                {
                    sb.Append(curSymbol);
                }
                else
                {
                    power--;
                }
                
            }

            Console.WriteLine(sb);



        }

    }
}
