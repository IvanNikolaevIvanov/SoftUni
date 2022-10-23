﻿using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            var sb = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
