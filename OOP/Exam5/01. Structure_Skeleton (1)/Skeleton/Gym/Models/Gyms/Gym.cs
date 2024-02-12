using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {

        private IRepository<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name= name;
            Capacity= capacity;

            equipment = new EquipmentRepository();
            athletes = new List<IAthlete>();
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IEquipment> Equipment => (ICollection<IEquipment>)equipment.Models;

        public ICollection<IAthlete> Athletes => athletes;

        public double EquipmentWeight => this.equipment.Models.Sum(x => x.Weight);

        

        public void AddAthlete(IAthlete athlete)
        {
            if (this.athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            else
            {
                this.athletes.Add(athlete);
            }
            

        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {

            this.equipment.Add(equipment);

        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }

        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            string athletesToString = this.athletes.Any() ? String.Join(", ", this.athletes) : "No athletes";

            sb
                .AppendLine($"{Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {athletesToString}")
                .AppendLine($"Equipment total count: {this.equipment.Models.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().Trim();
        }

        
    }
}
