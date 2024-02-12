using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName= fullName;
            Motivation= motivation;
            NumberOfMedals= numberOfMedals;
            Stamina= stamina;
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            private set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                fullName = value;
            }
        }

        private string motivation;

        public string Motivation
        {
            get { return motivation; }
            private set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value; 
            }
        }


        public int Stamina { get; protected set; }

        private int numberOfMedals;

        public int NumberOfMedals
        {
            get { return numberOfMedals; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                numberOfMedals = value;
            }
        }


        

        public virtual void Exercise()
        {

        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
