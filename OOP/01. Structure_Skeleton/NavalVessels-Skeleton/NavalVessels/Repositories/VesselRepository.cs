using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new HashSet<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models 
            => (IReadOnlyCollection<IVessel>)this.vessels; 

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public bool Remove(IVessel model)
            => vessels.Remove(model);
        

        public IVessel FindByName(string name)
        {
            return vessels.FirstOrDefault(m => m.Name == name);
        }

        
    }
}
