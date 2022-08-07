using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private readonly ICollection<IVessel> vessels;
        private Captain()
        {
            vessels = new HashSet<IVessel>();
            combatExperience = 0;
        }
        public Captain(string fullName):this()
        {
            this.FullName = fullName;
        }
        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get
            {
                return combatExperience;
            }
            private set
            {
                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if(vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {vessels.Count} vessels.");
            if(vessels.Count > 0)
            {
                foreach(IVessel vessel in vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
