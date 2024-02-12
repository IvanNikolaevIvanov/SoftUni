using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {

        private readonly ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models 
            => (IReadOnlyCollection<IFormulaOneCar>)this.models;

        public void Add(IFormulaOneCar car)
        {
            models.Add(car);
        }

        public bool Remove(IFormulaOneCar car)
        {
            return models.Remove(car);
        }

        public IFormulaOneCar FindByName(string model)
        {

            return models.FirstOrDefault(m => m.Model == model);
            
        }

      
    }
}
