using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothID = booths.Models.Count + 1;

            IBooth newBooth = new Booth(boothID, capacity);

            booths.AddModel(newBooth);

            return String.Format(OutputMessages.NewBoothAdded, boothID, capacity);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);

            IDelicacy delicacy = null;

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);

            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName); 
            }

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName); 
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName); 


        }


        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);

            ICocktail cocktail = null;

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);

            }

            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);

            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            }

            booth.CocktailMenu.AddModel(cocktail);

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string ReserveBooth(int countOfPeople)
        {
            var orderedBooths = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId);

            var booth = orderedBooths.FirstOrDefault();

            if (booth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);

        }

        public string TryOrder(int boothId, string order)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);

            string size = string.Empty;

            double price = 0;

            string[] orderInfo = order.Split('/', StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            int count = int.Parse(orderInfo[2]);
            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                size = orderInfo[3];
            }

            if (itemTypeName != "MulledWine" && itemTypeName != "Hibernation"
                && itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName)
                && !booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
            {
                return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

            }

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                var cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(c => c.Name == itemName && c.Size == size);

                if (cocktail == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, size, itemName);

                }

                price = cocktail.Price * count;
               
            }

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

                }

                price = delicacy.Price * count;
                
            }

            booth.UpdateCurrentBill(price);

            return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);

        }

        public string LeaveBooth(int boothId)
        {
            StringBuilder sb = new StringBuilder();

            var booth = booths.Models.First(b => b.BoothId == boothId);

            double bill = booth.CurrentBill;

            booth.Charge();
            booth.ChangeStatus();

            sb
                .AppendLine($"Bill {bill:f2} lv")
                .AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);

            return booth.ToString();

        }






    }
}
