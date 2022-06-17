using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char firstCh = (char)('a' + i);

                        char secondCh = (char)('a' + j);
                        
                        char thirdCh = (char)('a' + k);
                        Console.WriteLine($"{firstCh}{secondCh}{thirdCh}");
                    }
                }

                    
                }

                

            
        }
    }
}
