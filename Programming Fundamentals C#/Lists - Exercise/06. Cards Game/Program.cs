using System;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

            int firstPlayerCounter = 0;
            int secondPlayerCounter = 0;


            while (firstHand.Count > 0 && secondHand.Count > 0)
            {
                
                    if (firstHand[0] > secondHand[0])
                    {
                        firstPlayerCounter++;
                        
                        firstHand.Add(firstHand[0]);
                        firstHand.Add(secondHand[0]);
                    }
                    else if (firstHand[0] < secondHand[0])
                    {
                        secondPlayerCounter++;
                        
                        secondHand.Add(secondHand[0]);
                        secondHand.Add(firstHand[0]);                        
                    }

                firstHand.RemoveAt(0);
                secondHand.RemoveAt(0);
                
                    
                
            }

            if (firstPlayerCounter > secondPlayerCounter)
            {
                Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
            }
        }
    }
}
