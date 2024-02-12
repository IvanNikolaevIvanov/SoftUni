
namespace SimpleSnake.GameObjects.Foods
{
using System;

    public class FoodHash : Food
    {
        private const char DEFAULT_SYMBOL = '#';
        private const int DEFAULT_POINTS = 3;
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.Cyan;


        public FoodHash(Wall wall) 
            : base(wall, DEFAULT_SYMBOL, DEFAULT_POINTS, DEFAULT_COLOR)
        {
        }
    }
}
