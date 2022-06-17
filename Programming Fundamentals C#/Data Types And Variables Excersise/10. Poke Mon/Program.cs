using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            byte exhaustionFactorY = byte.Parse(Console.ReadLine());
            int percentOfOriginalValue = pokePowerN / 2;
            int pokedTargets = 0;
            
            

            while (pokePowerN >= distanceM)
            {
                pokedTargets++;
                
                pokePowerN -= distanceM;

                if (pokePowerN == percentOfOriginalValue)
                {
                    if (exhaustionFactorY > 0)
                    {
                        pokePowerN /= exhaustionFactorY;
                    }
                }

                

            }

            Console.WriteLine(pokePowerN);
            Console.WriteLine(pokedTargets);

        }
    }
}
