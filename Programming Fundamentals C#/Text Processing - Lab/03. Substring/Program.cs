using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string target = Console.ReadLine();
            int startIndex = 0;

            while (true)
            {
                startIndex = target.IndexOf(key);

                if (startIndex == -1)
                {
                    break;
                }
                
                target = target.Remove(startIndex, key.Length); ;
            }

            Console.WriteLine(target);
           
        }
    }
}
