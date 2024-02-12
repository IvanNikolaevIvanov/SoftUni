
namespace SimpleSnake.GameObjects.Foods
{
using System;

    public class FoodDollar : Food
    {
        private const char DEFAULT_SYMBOL = '$';
        private const int DEFAULT_POINTS = 2;
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.Green;

        public FoodDollar(Wall wall) 
            : base(wall, DEFAULT_SYMBOL, DEFAULT_POINTS, DEFAULT_COLOR)
        {
        }
    }
}
