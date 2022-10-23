using System;
using System.Collections.Generic;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> validUsernames = new List<string>();

            foreach (var name in input)
            {
                

                if (name.Length >= 3 && name.Length <= 16)
                {
                    bool isValid = true;

                    for (int i = 0; i < name.Length; i++)
                    {
                        char currChar = name[i];

                        if (!(char.IsLetterOrDigit(currChar) || currChar == '-' || currChar == '_'))
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        validUsernames.Add(name);
                    }
                }

                
            }

            Console.WriteLine(String.Join(Environment.NewLine, validUsernames));

        }
    }
}
