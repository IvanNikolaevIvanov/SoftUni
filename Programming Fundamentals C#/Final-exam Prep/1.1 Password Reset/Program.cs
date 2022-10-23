using System;
using System.Text;

namespace _1._1_Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Done")
                {
                    break;
                }

                string command = commands[0];

                switch (command)
                {
                    case "TakeOdd":

                        input = TakeOdd(input);

                        break;
                    case "Cut":

                        input = Cut(input, int.Parse(commands[1]), int.Parse(commands[2]));

                        break;
                    case "Substitute":

                        input = Substitute(input, commands[1], commands[2]);

                        break;
                }

            }

            Console.WriteLine($"Your password is: {input}");
        }

        static string Substitute(string input, string substring, string substitude)
        {
            if (input.Contains(substring))
            {
                input = input.Replace(substring, substitude);

                Console.WriteLine(input);

                
            }
            else 
            {
                Console.WriteLine("Nothing to replace!");
            }


            return input;
        }

        static string Cut(string input, int startIndex, int length)
        {
            input = input.Remove(startIndex, length);

            Console.WriteLine(input);
            return input;
        }

        static string TakeOdd(string input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0)
                {
                                       
                    sb.Append(input[i]);
                }
            }

            Console.WriteLine(sb.ToString());
            return input = sb.ToString();
        }
    }
}
