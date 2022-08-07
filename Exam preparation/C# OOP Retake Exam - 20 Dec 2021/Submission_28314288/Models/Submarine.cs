namespace NavalVessels.Models
{
	using NavalVessels.Models.Contracts;
	using System;

	public class Submarine : Vessel, ISubmarine
	{
		private const double InitialArmorThickness = 200;
		private bool submergeMode;

		public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
		{
			this.SubmergeMode = false;
		}

		public bool SubmergeMode
		{
			get => this.submergeMode;
			private set => this.submergeMode = value;
		}

		public override void RepairVessel()
		{
			this.ArmorThickness = InitialArmorThickness;
		}

		public void ToggleSubmergeMode()
		{
			this.submergeMode = !this.SubmergeMode;

			if (this.submergeMode)
			{
				this.MainWeaponCaliber += 40;
				this.Speed -= 4;
			}
			else
			{
				this.MainWeaponCaliber -= 40;
				this.Speed += 4;
			}
		}

		public override string ToString() => base.ToString() + Environment.NewLine + $" *Submerge mode: {(this.SubmergeMode ? "ON": "OFF")}";
	}
}
