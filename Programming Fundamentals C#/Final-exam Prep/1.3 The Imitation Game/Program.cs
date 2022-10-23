using System;
using System.Text;

namespace _1._3_The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Decode")
                {
                    break;
                }

                string command = commands[0];

                switch (command)
                {
                    case "Move":
                        message = Move(message, int.Parse(commands[1]));
                        break;

                    case "Insert":
                        message = Insert(message, int.Parse(commands[1]), commands[2]);
                        break;

                    case "ChangeAll":
                        message = ChangeAll(message, commands[1], commands[2]);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        static string ChangeAll(string message, string substring, string replacement)
        {

            message = message.Replace(substring, replacement);
            
            return message;
        }

        static string Insert(string message, int index, string value)
        {

            message = message.Insert(index, value);
            
            return message;

        }

        static string Move(string message, int numberOfLetters)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < numberOfLetters; i++)
            {
                sb.Append(message[i]);
            }
            message = message.Remove(0, numberOfLetters);
            message = message + sb;

            return message;

        }
    }
}
