using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);

            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }


        public string AddEquipment(string equipmentType)
        {
            IEquipment equipmentToAdd = null;

            if (equipmentType == "BoxingGloves")
            {
                equipmentToAdd = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipmentToAdd = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(equipmentToAdd);

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);

        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym = gyms.First(g => g.Name == gymName);

            IEquipment equipmentToInsert = equipment.FindByType(equipmentType);

            if (equipmentToInsert == null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipmentToInsert);

            this.equipment.Remove(equipmentToInsert);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gym.Name);


        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;

            IGym gym = gyms.First(g => g.Name == gymName);

            string gymType = gym.GetType().Name;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }


            if (athleteType == "Boxer" && gymType == "BoxingGym")
            {
                gym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter" && gymType == "WeightliftingGym")
            {
                gym.AddAthlete(athlete);
            }
            else
            {
                return String.Format(OutputMessages.InappropriateGym);
            }

            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gym.Name);

        }


        public string TrainAthletes(string gymName)
        {
            var gym = gyms.First(g => g.Name == gymName);

            gym.Exercise();

            return $"Exercise athletes: {gym.Athletes.Count}.";

        }


        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.First(g => g.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";
        }



        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }


            return sb.ToString().Trim();
        }

        
    }
}
