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
        private bool tookPlace;
        private ICollection<IPilot> pilots;
        private Race()
        {
            this.pilots = new HashSet<IPilot>();
            this.TookPlace = false;
        }
        public Race(string raceName, int numberOfLaps) : this()
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }
        public string RaceName
        {
            get => raceName;
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get => tookPlace;
            set
            {
                this.tookPlace = value;
            }
        }

        public ICollection<IPilot> Pilots
        {
            get => pilots;

        }

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.RaceName} race has:")
                .AppendLine($"Participants: {this.Pilots.Count}")
                .AppendLine($"Number of laps: {this.NumberOfLaps}")
                .Append($"Took place: {(TookPlace == true ? "Yes" : "No")}");
            return sb.ToString().TrimEnd();
        }
    }
}
