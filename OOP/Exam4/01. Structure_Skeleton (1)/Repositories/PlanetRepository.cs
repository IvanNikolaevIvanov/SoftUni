using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();
        

        public IPlanet FindByName(string name)
        {

            return this.models.FirstOrDefault(m => m.Name == name);

        }

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            var planet = this.models.FirstOrDefault(p => p.Name == name);

            if (planet != null)
            {
                return this.models.Remove(planet);
            }
            else
            {
                return false;
            }

        }

        

        

        

        
    }
}
