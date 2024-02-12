using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAt : Food
    {
        private const char DEFAULT_SYMBOL = '@';
        private const int DEFAULT_POINTS = 4;
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.Magenta;

        public FoodAt(Wall wall) 
            : base(wall, DEFAULT_SYMBOL, DEFAULT_POINTS, DEFAULT_COLOR)
        {
        }
    }
}
