using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {

        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName= raceName;
            NumberOfLaps= numberOfLaps;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }


        public int  NumberOfLaps
        {
            get { return numberOfLaps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));

                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; } = false;

        public ICollection<IPilot> Pilots { get => pilots; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);

        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            string tookPlaceResult = this.TookPlace ? "Yes" : "No";

            sb
                .AppendLine($"The {RaceName} race has:")
                .AppendLine($"Participants: {Pilots.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}")
                .AppendLine($"Took place: {tookPlaceResult}");

            return sb.ToString().TrimEnd();
        }
    }
}
