using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private IRepository<IDelicacy> delicacies;
        private IRepository<ICocktail> cocktails;

        public Booth()
        {
            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();
        }

        public Booth(int boothId, int capacity) : this()
        {
            BoothId= boothId;
            Capacity= capacity;

            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }

        public int BoothId { get; private set; }
        
        
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacies;

        public IRepository<ICocktail> CocktailMenu => cocktails;


        public double CurrentBill { get; private set; }
       

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }


        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;

        }

        public void Charge()
        {
            Turnover += CurrentBill;

            CurrentBill = 0;

        }

        public void ChangeStatus()
        {
            IsReserved = !IsReserved;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Booth: {BoothId}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Turnover: {Turnover:F2} lv");

            sb.AppendLine("-Cocktail menu:");

            foreach (var cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delcacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delcacy.ToString()}");
            }

            return sb.ToString().Trim();
        }


    }
}
