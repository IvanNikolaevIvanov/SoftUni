using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var bannedWord in banList)
            {
                string replacement = new string('*', bannedWord.Length);

                if (text.Contains(bannedWord))
                {
                    text = text.Replace(bannedWord, replacement);
                }
                
            }

            Console.WriteLine(text);
        }
    }
}
