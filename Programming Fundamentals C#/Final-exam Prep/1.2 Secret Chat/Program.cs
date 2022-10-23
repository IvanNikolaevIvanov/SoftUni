using System;

namespace _1._2_Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Reveal")
                {
                    break;
                }

                string command = commands[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(commands[1]);
                    string space = " ";
                    input = input.Insert(index, space);

                    Console.WriteLine(input);

                }
                if (command == "Reverse")
                {
                    string substring = commands[1];

                    if (input.Contains(substring))
                    {
                        int startIndex = input.IndexOf(substring);

                        input = input.Remove(startIndex, substring.Length);

                        string reversedSubstring = String.Empty;
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring += substring[i];
                        }
                        
                        input += reversedSubstring;

                        Console.WriteLine(input);

                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                if (command == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];
                    while (input.Contains(substring))
                    {

                        input = input.Replace(substring, replacement);

                    }

                    Console.WriteLine(input);
                }


            }

            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
