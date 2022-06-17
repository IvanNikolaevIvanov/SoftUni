using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int num = int.Parse(Console.ReadLine());

            

            Console.WriteLine(StringRepeat(input, num));
        }

        private static string StringRepeat(string input, int num)
        {
            string result = "";
            for (int i = 0; i < num; i++)
            {
                result += input;
            }

            return result;
        }

        //private static string RepeatString(string str, int count)
        //{
        //    StringBuilder result = new StringBuilder();
        //    for (int i = 0; i < count; i++)
        //        result.Append(str);
        //    return result.ToString();
        //}

    }
}
