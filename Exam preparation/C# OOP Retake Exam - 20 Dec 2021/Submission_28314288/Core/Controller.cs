namespace NavalVessels.Core
{
	using NavalVessels.Core.Contracts;
	using NavalVessels.Models;
	using NavalVessels.Models.Contracts;
	using NavalVessels.Repositories;
	using NavalVessels.Utilities.Messages;
	using System.Collections.Generic;
	using System.Linq;

	public class Controller : IController
	{
		private VesselRepository vessels;
		private List<ICaptain> captains;

		public Controller()
		{
			this.captains = new List<ICaptain>();
			this.vessels = new VesselRepository();
		}

		public string HireCaptain(string fullName)
		{
			ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == fullName);

			if (captain != null)
			{
				return string.Format(OutputMessages.CaptainIsAlreadyHired, captain.FullName);
			}

			captain = new Captain(fullName);
			this.captains.Add(captain);

			return string.Format(OutputMessages.SuccessfullyAddedCaptain, captain.FullName);
		}

		public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
		{
			IVessel vessel = this.vessels.FindByName(name);

			if (vessel != null)
			{
				return string.Format(OutputMessages.VesselIsAlreadyManufactured, vessel.GetType().Name, vessel.Name);
			}

			if (vesselType == "Submarine")
			{
				vessel = new Submarine(name, mainWeaponCaliber, speed);
			}
			else if (vesselType == "Battleship")
			{
				vessel = new Battleship(name, mainWeaponCaliber, speed);
			}
			else
			{
				return OutputMessages.InvalidVesselType;
			}

			this.vessels.Add(vessel);

			return string.Format(OutputMessages.SuccessfullyCreateVessel, vessel.GetType().Name, vessel.Name, vessel.MainWeaponCaliber, vessel.Speed);
		}

		public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
		{
			ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

			if (captain == null)
			{
				return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
			}

			IVessel vessel = this.vessels.FindByName(selectedVesselName);

			if (vessel == null)
			{
				return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
			}

			if (vessel.Captain != null)
			{
				return string.Format(OutputMessages.VesselOccupied, vessel.Name);
			}

			vessel.Captain = captain;
			captain.Vessels.Add(vessel);

			return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
		}

		public string CaptainReport(string captainFullName) => this.captains.FirstOrDefault(x => x.FullName == captainFullName).Report();

		public string VesselReport(string vesselName) => this.vessels.FindByName(vesselName).ToString();

		public string ToggleSpecialMode(string vesselName)
		{
			IVessel vessel = this.vessels.FindByName(vesselName);			

			if (vessel is Battleship)
			{
				(vessel as Battleship).ToggleSonarMode();
				return string.Format(OutputMessages.ToggleBattleshipSonarMode, vessel.Name);
			}
			else if (vessel is Submarine)
			{
				(vessel as Submarine).ToggleSubmergeMode();
				return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vessel.Name);
			}

			return string.Format(OutputMessages.VesselNotFound, vesselName);
		}

		public string ServiceVessel(string vesselName)
		{
			IVessel vessel = this.vessels.FindByName(vesselName);

			if (vessel == null)
			{
				return string.Format(OutputMessages.VesselNotFound, vesselName);
			}

			vessel.RepairVessel();

			return string.Format(OutputMessages.SuccessfullyRepairVessel, vessel.Name);
		}

		public string AttackVessels(string attackingVesselName, string defendingVesselName)
		{
			IVessel attaker = this.vessels.FindByName(attackingVesselName);
			IVessel defender = this.vessels.FindByName(defendingVesselName);

			if (attaker == null)
			{
				return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
			}
			else if (defender == null)
			{
				return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
			}

			if (attaker.ArmorThickness <= 0)
			{
				return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
			}
			else if (defender.ArmorThickness <= 0)
			{
				return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
			}

			attaker.Attack(defender);
			attaker.Captain.IncreaseCombatExperience();
			defender.Captain.IncreaseCombatExperience();

			return string.Format(OutputMessages.SuccessfullyAttackVessel, defender.Name, attaker.Name, defender.ArmorThickness);
		}
	}
}
