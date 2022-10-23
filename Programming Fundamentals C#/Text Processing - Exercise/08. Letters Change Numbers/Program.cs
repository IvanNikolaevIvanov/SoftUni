using System;
using System.Text;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            double curNum = 0;


            foreach (var item in input)
            {
                

                StringBuilder sb = new StringBuilder();

                for (int i = 1; i < item.Length - 1; i++)
                {
                    sb.Append(item[i]);
                }

                curNum = double.Parse(sb.ToString());

                char firstLetter = item[0];
                char lastLetter = item[item.Length - 1];

                double result = 0;

                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    int flposition = firstLetter - 64;
                    result = curNum / flposition;

                }
                else
                {
                    int flposition = firstLetter - 96;
                    result = curNum * flposition;
                }

                if (lastLetter >= 65 && lastLetter <= 90)
                {
                    int llposition = lastLetter - 64;
                    sum += result - llposition;
                }
                else
                {
                    int llposition = lastLetter - 96;
                    sum += result + llposition;
                }

                
            }

            Console.WriteLine($"{sum:f2}");


        }
    }
}
