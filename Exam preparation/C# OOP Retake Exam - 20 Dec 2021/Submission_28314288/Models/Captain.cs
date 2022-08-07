namespace NavalVessels.Models
{
	using NavalVessels.Models.Contracts;
	using NavalVessels.Utilities.Messages;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class Captain : ICaptain
	{
		private string fullName;
		private int combatExperience;
		private readonly ICollection<IVessel> vessels;

		private Captain()
		{
			this.vessels = new HashSet<IVessel>();
			this.CombatExperience = 0;
		}

		public string FullName
		{
			get => this.fullName;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
				}

				this.fullName = value;
			}
		}

		public Captain(string fullName) : this()
		{
			this.FullName = fullName;
		}

		public int CombatExperience
		{
			get => this.combatExperience;
			private set => this.combatExperience = value;
		}

		public ICollection<IVessel> Vessels => this.vessels;

		public void AddVessel(IVessel vessel)
		{
			if (vessel == null)
			{
				throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
			}

			this.Vessels.Add(vessel);
		}

		public void IncreaseCombatExperience()
		{
			this.combatExperience += 10;			
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

			foreach (IVessel vessel in this.Vessels)
			{
				sb.AppendLine(vessel.ToString());
			}

			return sb.ToString().TrimEnd();
		}
	}
}
