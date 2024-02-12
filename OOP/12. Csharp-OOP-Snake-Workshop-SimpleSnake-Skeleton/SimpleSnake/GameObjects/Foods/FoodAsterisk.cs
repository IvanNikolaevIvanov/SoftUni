
namespace SimpleSnake.GameObjects.Foods
{
using System;

    public class FoodAsterisk : Food
    {
        private const char DEFAULT_SYMBOL = '*';
        private const int DEFAULT_POINTS = 1;
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.Red;

        public FoodAsterisk(Wall wall) 
            : base(wall, DEFAULT_SYMBOL, DEFAULT_POINTS, DEFAULT_COLOR)
        {
        }
    }
}
