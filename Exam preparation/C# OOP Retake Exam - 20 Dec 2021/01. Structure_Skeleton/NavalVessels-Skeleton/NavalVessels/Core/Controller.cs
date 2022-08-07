using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vessels;
        private List<ICaptain> captains;
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain newCaptain = new Captain(fullName);
            foreach (ICaptain captain in captains)
            {
                if(captain.FullName == newCaptain.FullName)
                {
                    return $"Captain {fullName} is already hired.";
                }
            }
            
            captains.Add(newCaptain);
            return $"Captain {fullName} is hired.";
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name,mainWeaponCaliber,speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return "Invalid vessel type.";
            }
            if(vessels.FindByName(name) != null)
            {
                IVessel foundVessel = vessels.FindByName(name);
                return $"{foundVessel.GetType().Name} vessel {name} is already manufactured.";
            }
            else
            {
                vessels.Add(vessel);
                return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
            }
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain selectedCaptain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            if (selectedCaptain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            IVessel selectedVessel = vessels.FindByName(selectedVesselName);
            if(selectedVessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if(selectedVessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            else
            {
                selectedVessel.Captain = selectedCaptain;
                selectedCaptain.AddVessel(selectedVessel);
                return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
            }

        }

        public string CaptainReport(string captainFullName) => this.captains.FirstOrDefault(x => x.FullName == captainFullName).Report();

        public string VesselReport(string vesselName) => this.vessels.FindByName(vesselName).ToString();
        

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel selectedVessel = vessels.FindByName(vesselName);
            if (selectedVessel == null)
                return $"Vessel {vesselName} could not be found.";

            if (selectedVessel.GetType() == typeof(Submarine))
            {
                Submarine submarine = (Submarine)selectedVessel;
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
            if(selectedVessel.GetType() == typeof(Battleship))
            {
                Battleship battleship = (Battleship)selectedVessel;
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            return null;
        }
        public string ServiceVessel(string vesselName)
        {
            IVessel selectedVessel = vessels.FindByName(vesselName);
            if (selectedVessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            selectedVessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackVessel = vessels.FindByName(attackingVesselName);
            IVessel defendVessel = vessels.FindByName(defendingVesselName);
            if(attackVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if(defendVessel == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            if(attackVessel.ArmorThickness <= 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defendVessel.ArmorThickness <= 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }
            attackVessel.Attack(defendVessel);
            attackVessel.Captain.IncreaseCombatExperience();
            defendVessel.Captain.IncreaseCombatExperience();
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendVessel.ArmorThickness}.";
        }

     

        
        

       
    }
}
