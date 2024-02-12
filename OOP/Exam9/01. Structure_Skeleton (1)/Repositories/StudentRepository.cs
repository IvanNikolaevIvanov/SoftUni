using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => models.AsReadOnly();

        public void AddModel(IStudent model)
        {
            models.Add(model);

        }

        public IStudent FindById(int id)
        {

            return this.models.FirstOrDefault(m => m.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] nameinfo = name.Split(" ");
            string firstName = nameinfo[0];
            string lastName = nameinfo[1];

            return this.models.FirstOrDefault(s => s.FirstName== firstName && s.LastName == lastName);

        }
    }
}
