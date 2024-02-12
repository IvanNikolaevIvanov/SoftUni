using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private List<int> subjects;

        public University()
        {
            subjects= new List<int>();
        }

        public University(int universityId, string universityName, string category, int capacity,
                          ICollection<int> requiredSubjects) : this() 
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            subjects = requiredSubjects.ToList();
        }
        
        public int Id { get; private set; }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        private string category;

        public string Category
        {
            get { return category; }
            private set 
            {
                if (value != "Technical" && value != "Economical" && value != "Humanity")
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CategoryNotAllowed, value));

                }
                category = value;
            }
        }


        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);

                }
                capacity = value;
            }
        }
        

        public IReadOnlyCollection<int> RequiredSubjects => subjects.AsReadOnly();
    }
}
