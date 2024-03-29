﻿using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {

        protected Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id= subjectId;
            Name= subjectName;
            Rate = subjectRate;
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

        

        public double Rate { get; private set; }
    }
}
