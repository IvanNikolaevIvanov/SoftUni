using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split('\\', StringSplitOptions.RemoveEmptyEntries);

            int fileNameAndExtPositon = input.Length - 1;

            string[] fileNameandExt = input[fileNameAndExtPositon].Split('.');

            

            Console.WriteLine($"File name: {fileNameandExt[0]}");
            Console.WriteLine($"File extension: {fileNameandExt[1]}");


        }
    }
}
