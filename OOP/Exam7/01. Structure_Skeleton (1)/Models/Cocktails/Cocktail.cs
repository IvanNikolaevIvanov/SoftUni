using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {

        protected Cocktail(string cocktailName, string size, double price)
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
            get 
            { 
                return price;
            }
            protected set 
            {
                if (Size == "Small")
                {
                    price = value * 1.00 /3.00;
                }
                else if (Size == "Middle")
                {
                    price = value * 2.00 / 3.00;

                }
                else if (Size == "Large")
                {
                    price = value;
                }
                
            }
        }


        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {Price:F2} lv";
        }

    }
}
