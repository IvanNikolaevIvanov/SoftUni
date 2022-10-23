using System;

namespace _1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "End")
                {
                    break;
                }

                string command = commands[0];

                switch (command)
                {

                    case "Translate":

                        input = Translate(input, commands[1], commands[2]);
                        break;

                    case "Includes":

                        Includes(input, commands[1]);
                        break;

                    case "Start":

                        Start(input, commands[1]);
                        break;

                    case "Lowercase":

                        input = Lowercase(input);
                        break;

                    case "FindIndex":

                        FindIndex(input, char.Parse(commands[1]));
                        break;

                    case "Remove":

                        input = Remove(input, int.Parse(commands[1]), int.Parse(commands[2]));
                        break;
                }
            }



        }

        static string Remove(string input, int startIndex, int count)
        {
            input = input.Remove(startIndex, count);

            Console.WriteLine(input);
            
            return input;
        }

        static void FindIndex(string input, char letter)
        {
            int lastIndexOf = input.LastIndexOf(letter);

            Console.WriteLine(lastIndexOf);
        }

        static string Lowercase(string input)
        {
            input = input.ToLower();

            Console.WriteLine(input);
            
            return input;
        }

       static void Start(string input, string substring)
        {
            string checkString = input.Substring(0, substring.Length);
            if (checkString == substring)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            
            
        }

        static void Includes(string input, string substring)
        {
            if (input.Contains(substring))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            
            
            
        }

        static string Translate(string input, string originalChar, string replacement)
        {
            input = input.Replace(originalChar, replacement);


            Console.WriteLine(input);
            
            return input;
        }
    }
}
