using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private List<int> coveredExams;

        public Student()
        {
            coveredExams= new List<int>();
        }


        public Student(int studentId, string firstName, string lastName) : this() 
        {
            Id= studentId;
            FirstName= firstName;
            LastName= lastName;
        }

        
        public int Id { get; private set; }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                firstName = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        }
        

        public IReadOnlyCollection<int> CoveredExams => coveredExams.AsReadOnly();

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            int id = subject.Id;
            this.coveredExams.Add(id);

        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university;

        }
    }
}
