using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {

        private IRepository<IDecoration> decorations;
        private List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            decorations = new DecorationRepository();
            fish = new List<IFish>();
        }


        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IDecoration> Decorations => (ICollection<IDecoration>)this.decorations.Models;

        public ICollection<IFish> Fish => this.fish;


        public int Comfort => (int)this.Decorations.Sum(d => d.Comfort);

        

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);

        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            else
            {
                this.Fish.Add(fish);
            }

        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);

        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }

        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string FishToString = Fish.Any() ? String.Join(", ", Fish) : "none";

            sb
                .AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {FishToString}")
                .AppendLine($"Decorations: {Decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().Trim();
        }

        
    }
}
