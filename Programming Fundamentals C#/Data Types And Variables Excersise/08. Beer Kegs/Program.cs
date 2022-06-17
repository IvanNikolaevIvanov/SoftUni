using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string model = "";
            double radius = 0;
            int height = 0;

            double volume = 0;

            for (int i = 0; i < n; i++)
            {
               string currentModel = Console.ReadLine();
               radius = double.Parse(Console.ReadLine());
               height = int.Parse(Console.ReadLine());

               double currentVolume = (Math.PI) * (Math.Pow(radius, 2)) * height;

                if (currentVolume > volume)
                {
                    volume = currentVolume;
                    model = currentModel;
                }

            }

            Console.WriteLine(model);
        }
    }
}
