using System;

namespace _1._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());

            double mToKm = meters / 1000;

            Console.WriteLine($"{mToKm:f2}");
        }
    }
}
