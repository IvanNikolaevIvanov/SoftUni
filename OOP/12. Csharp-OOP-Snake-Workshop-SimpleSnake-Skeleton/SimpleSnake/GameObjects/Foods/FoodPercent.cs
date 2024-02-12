
using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodPercent : Food
    {
        private const char DEFAULT_SYMBOL = '%';
        private const int DEFAULT_POINTS = 5;
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.Blue;

        public FoodPercent(Wall wall) 
            : base(wall, DEFAULT_SYMBOL, DEFAULT_POINTS, DEFAULT_COLOR)
        {
        }
    }
}
