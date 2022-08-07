namespace NavalVessels.Models
{
	using NavalVessels.Models.Contracts;
	using System;

	public class Battleship : Vessel, IBattleship
	{
		const double InitialArmorThickness = 300;
		private bool sonarMode;

		public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
		{
			this.SonarMode = false;
		}

		public bool SonarMode
		{
			get => this.sonarMode;
			private set => this.sonarMode = value;
		}

		public override void RepairVessel()
		{
			this.ArmorThickness = InitialArmorThickness;
		}

		public void ToggleSonarMode()
		{
			this.SonarMode = !this.SonarMode;

			if (this.SonarMode)
			{
				this.MainWeaponCaliber += 40;
				this.Speed -= 5;
			}
			else
			{
				this.MainWeaponCaliber -= 40;
				this.Speed += 5;
			}
		}

		public override string ToString() => base.ToString() + Environment.NewLine + $" *Sonar mode: {(this.SonarMode ? "ON": "OFF")}";
		
	}
}
