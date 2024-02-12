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
            int boothId = this.booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);

        }

        

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.First(m => m.BoothId == boothId); 

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
            var booth = booths.Models.First(m => m.BoothId == boothId);

            ICocktail cocktail = null;

            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
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

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);

            }

            booth.CocktailMenu.AddModel(cocktail);

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);


        }

        public string ReserveBooth(int countOfPeople)
        {
            var orderedBooths = this.booths.Models
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
            

            string size = string.Empty;

            string[] elements = order.Split('/', StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = elements[0];
            string itemName = elements[1];
            int count = int.Parse(elements[2]);
            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                 size = elements[3];
            }

            var booth = booths.Models.First(m => m.BoothId == boothId);

            

            if (!booth.CocktailMenu.Models.Any(m => m.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(m => m.Name == itemName))
            {
                return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

            }

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                var curItem = booth.CocktailMenu.Models
                    .FirstOrDefault(m => m.Name == itemName && m.Size == size);

                if (curItem == null)
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, size, itemName);

                }

                booth.UpdateCurrentBill(curItem.Price * count);

                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);


            }

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                var curItem = booth.DelicacyMenu.Models
                    .FirstOrDefault(m => m.GetType().Name == itemTypeName && m.Name == itemName);

                if (curItem == null)
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);

                }

                booth.UpdateCurrentBill(curItem.Price * count);

                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);

            }


            return String.Format(OutputMessages.NotRecognizedType, itemTypeName);

        }


        public string LeaveBooth(int boothId)
        {
            StringBuilder sb = new StringBuilder();

            var booth = booths.Models.First(m => m.BoothId == boothId);

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
            StringBuilder sb = new StringBuilder();

            var booth = booths.Models.First(m => m.BoothId == boothId);

            sb.AppendLine($"{booth}");

            sb.AppendLine("-Cocktail menu:");
            foreach (var cocktail in booth.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in booth.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }


            return sb.ToString().Trim();
        }






    }
}
