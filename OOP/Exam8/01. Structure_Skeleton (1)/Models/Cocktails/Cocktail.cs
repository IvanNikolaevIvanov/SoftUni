using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {

        public Cocktail(string cocktailName, string size, double price)
        {
            Name= cocktailName;
            Size= size;
            Price= price;
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size { get; private set; }

        private double price;

        public double Price
        {
            get { return price; }
            private set 
            {
                if (Size == "Large")
                {
                    price = value;

                }
                else if (Size == "Middle")
                {
                    price = value * 2.0 / 3.0;
                }
                else if (Size == "Small")
                {
                    price = value * 1.0 / 3.0;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }


    }
}
