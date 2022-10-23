using System;

namespace _1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] instructions = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                if (instructions[0] == "Generate")
                {
                    break;
                }

                string command = instructions[0];

                switch (command)
                {
                    case "Contains":

                        Contains(input, instructions[1]);

                        break;

                    case "Flip":

                        input = Flip(input, instructions[1], int.Parse(instructions[2]), int.Parse(instructions[3]));

                        break;

                    case "Slice":

                        input = Slice(input, int.Parse(instructions[1]), int.Parse(instructions[2]));

                        break;


                }
            }

            Console.WriteLine($"Your activation key is: {input}");
        }

        static string Slice(string input, int startIndex, int endIndex)
        {
            input = input.Remove(startIndex, endIndex - startIndex);
            Console.WriteLine(input);
            return input;
        }

        static string Flip(string input, string upperOrLower, int startIndex, int endIndex)
        {
            string originalSubstring = input.Substring(startIndex, endIndex - startIndex);
            string newSubstring = originalSubstring.ToLower();

            if (upperOrLower == "Upper")
            {                
                newSubstring = newSubstring.ToUpper();
            }

            input = input.Replace(originalSubstring, newSubstring);

            Console.WriteLine(input);
            return input;
        }

        static void Contains(string input, string substring)
        {
            if (input.Contains(substring))
            {
                Console.WriteLine($"{input} contains {substring}");
            }
            else 
            {
                Console.WriteLine($"Substring not found!");
            }
        }
    }
}
