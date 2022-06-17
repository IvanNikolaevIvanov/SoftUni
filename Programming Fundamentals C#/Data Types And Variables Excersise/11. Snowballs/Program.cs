using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            BigInteger snow = 0;
            BigInteger time = 0;
            int quality = 0;
            BigInteger value = 0;
            BigInteger finalValue = 0;
            BigInteger finalSnow = 0;
            BigInteger finalTime = 0;
            int finalQuality = 0;

            for (int i = 0; i < N; i++)
            {
                
                snow = BigInteger.Parse(Console.ReadLine());
                time = BigInteger.Parse(Console.ReadLine());
                quality = int.Parse(Console.ReadLine());
                
                BigInteger division = snow / time;
                
                value = BigInteger.Pow(division, quality);
                
                if (value >= finalValue)
                {
                    finalValue = value;
                    finalSnow = snow;
                    finalTime = time;
                    finalQuality = quality;
                }               
            }

            Console.WriteLine($"{finalSnow} : {finalTime} = {finalValue} ({finalQuality})");
        }
    }
}
