using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] ladybugsField = new int[fieldSize];

            string[] occupiedIndexes = Console.ReadLine().Split();

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currentIndexes = int.Parse(occupiedIndexes[i]);
                if (currentIndexes >= 0 && currentIndexes < fieldSize)
                {
                    ladybugsField[currentIndexes] = 1;
                }
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                bool isFirst = true;
                int currentIndex = int.Parse(command[0]);

                while (currentIndex >= 0 && currentIndex < fieldSize
                    && ladybugsField[currentIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladybugsField[currentIndex] = 0;
                        isFirst = false;
                    }
                    string direction = command[1];
                    int flightLenght = int.Parse(command[2]);
                    if (direction == "left")
                    {
                        currentIndex -= flightLenght;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugsField[currentIndex] == 0)
                            {
                                ladybugsField[currentIndex] = 1;
                                break;
                            }
                        }

                    }
                    else
                    {
                        currentIndex += flightLenght;
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugsField[currentIndex] == 0)
                            {
                                ladybugsField[currentIndex] = 1;
                                break;
                            }
                        }


                    }

                }

                command = Console.ReadLine().Split();


            }

            Console.WriteLine(string.Join(" ", ladybugsField));
        }
    }
}
