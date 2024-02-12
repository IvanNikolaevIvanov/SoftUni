using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double WIEGHT = 227;
        private const decimal PRICE = 120;

        public BoxingGloves() : base(WIEGHT, PRICE)
        {
        }
    }
}
