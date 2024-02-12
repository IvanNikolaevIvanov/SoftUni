using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets= new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            var planet = new Planet(name, budget);

            if (planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            this.planets.AddItem(planet);

            return String.Format(OutputMessages.NewPlanet, name);

        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit unit = null;

            if (this.planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planets.FindByName(planetName);

            if (unitTypeName != "StormTroopers" && unitTypeName != "SpaceForces" &&
                unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

           

            if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();

            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();

            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {

            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planets.FindByName(planetName);

            if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);

            }
            else if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);

            }
            else
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);


        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);

            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);

        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = planets.FindByName(planetOne);
            var planet2 = planets.FindByName(planetTwo);

            IPlanet winner = null;
            IPlanet looser = null;

            List<IPlanet> list = new List<IPlanet>();
            list.Add(planet1);
            list.Add(planet2);

            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                looser = planet2;

            }
            else if (planet1.MilitaryPower < planet2.MilitaryPower)
            {
                winner = planet2;
                looser = planet1;

            }
            else
            {
                if (list.All(p => p.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                    || list.All(p => !p.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return String.Format(OutputMessages.NoWinner);

                }
                else
                {
                    winner = list.First(p => p.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"));
                    looser = list.First(p => !p.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"));
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            double addProfit = looser.Army.Sum(u => u.Cost);
            addProfit += looser.Weapons.Sum(w => w.Price);
            winner.Profit(addProfit);

            this.planets.RemoveItem(looser.Name);

            return String.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);

        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            var orderedPlanets = planets.Models.OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name);

            sb
                .AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo()); 

            }
                

            return sb.ToString().Trim();



        }




    }
}
