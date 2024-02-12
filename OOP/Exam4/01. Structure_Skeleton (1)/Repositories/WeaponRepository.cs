using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models= new List<IWeapon>();
        }
        
        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();


        public IWeapon FindByName(string name)
        {

            return this.models.FirstOrDefault(m => m.GetType().Name == name);

        }

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        

        public bool RemoveItem(string name)
        {
            var weapon = this.models.FirstOrDefault(m => m.GetType().Name == name);

            if (weapon != null)
            {
                return this.models.Remove(weapon);
            }
            else
            {
                return false;
            }
        
        }
    }
}
