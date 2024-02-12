using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();

       
        public IMilitaryUnit FindByName(string name)
        {

            return this.models.FirstOrDefault(m => m.GetType().Name == name);

        }

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            var unit = this.models.FirstOrDefault(u => u.GetType().Name == name);

            if (unit != null)
            {
                return this.models.Remove(unit);
            }
            else
            {
                return false;
            }

        }
    }
}
