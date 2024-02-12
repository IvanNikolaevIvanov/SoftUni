using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            var pilotToAdd = pilotRepository.FindByName(fullName);
            if (pilotToAdd != null) 
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);

            pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car = null;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.InvalidTypeCar, type));
            }

            carRepository.Add(car);

            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);   

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);


        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilotToAdd = pilotRepository.FindByName(pilotName);

            if (pilotToAdd == null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else if (pilotToAdd != null && pilotToAdd.Car != null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            var carToAdd = carRepository.FindByName(carModel);

            if (carToAdd == null)
            {
                throw new NullReferenceException(String
                    .Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilotToAdd.AddCar(carToAdd);

            string carType = carToAdd.GetType().Name;

            carRepository.Remove(carToAdd);

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, carType, carModel);


        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName (raceName);
            var pilot = pilotRepository.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException(String
                    .Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilot == null || pilot.CanRace == false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.Pilots.Add(pilot);

            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);

        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            
            if (race == null)
            {
                throw new NullReferenceException(String
                    .Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> orderedPilots = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            race.TookPlace = true;

            orderedPilots[0].WinRace();

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Pilot {orderedPilots[0].FullName} wins the {race.RaceName} race.")
                .AppendLine($"Pilot {orderedPilots[1].FullName} is second in the {race.RaceName} race.")
                .AppendLine($"Pilot {orderedPilots[2].FullName} is third in the {race.RaceName} race.");

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            List<IRace> execRaces = raceRepository.Models.Where(m => m.TookPlace == true).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var race in execRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string PilotReport()
        {
            List<IPilot> pilots = pilotRepository.Models
                .OrderByDescending(p => p.NumberOfWins).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();

        }

        

        
    }
}
