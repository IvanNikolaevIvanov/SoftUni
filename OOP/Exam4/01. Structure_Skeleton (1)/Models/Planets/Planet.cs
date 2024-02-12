using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
           => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons
            => weapons.Models;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }


        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }


        public double MilitaryPower 
        {
            get => this.MilitaryPowerCalculator();
            
        } 







        private double MilitaryPowerCalculator()
        {
            double totalAmount = 0;
            double enduranceSum = this.units.Models.Sum(x => x.EnduranceLevel);
            double destructionSum = this.weapons.Models.Sum(x => x.DestructionLevel);
            totalAmount = enduranceSum+ destructionSum;

            if (this.units.Models.Any(m => m.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.3;
            }

            if (this.weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += totalAmount * 0.45;
            }

            return Math.Round(totalAmount, 3);

        }

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in this.units.Models)
            {
                unit.IncreaseEndurance();
            }

        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string forces = this.units.Models.Any() ? String.Join(", ", this.Army) : "No units";

            string combatEquip = this.weapons.Models.Any() ? String.Join(", ", this.Weapons) : "No weapons";

            sb
                .AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine($"--Forces: {forces}")
                .AppendLine($"--Combat equipment: {combatEquip}")
                .AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();


        }

        public void Profit(double amount)
        {
            Budget += amount;

        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
            }
            else
            {
                Budget -= amount;
            }


        }

        
    }
}
