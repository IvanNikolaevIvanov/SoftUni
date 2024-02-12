using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double WIEGHT = 10_000;
        private const decimal PRICE = 80;

        public Kettlebell() : base(WIEGHT, PRICE)
        {
        }
    }
}
