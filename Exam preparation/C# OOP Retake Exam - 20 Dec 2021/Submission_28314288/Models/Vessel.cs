namespace NavalVessels.Models
{
	using NavalVessels.Models.Contracts;
	using NavalVessels.Utilities.Messages;
	using System;
	using System.Collections.Generic;
	using System.Text;

	public abstract class Vessel : IVessel
	{
		private string name;
		private ICaptain captain;
		private double armorThickness;
		private double mainWeaponCaliber;
		private double speed;
		private readonly ICollection<string> targets;

		protected Vessel()
		{
			this.targets = new HashSet<string>();
		}

		public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness) : this()
		{
			this.Name = name;
			this.MainWeaponCaliber = mainWeaponCaliber;
			this.Speed = speed;
			this.ArmorThickness = armorThickness;
		}

		public string Name
		{
			get => this.name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
				}

				this.name = value;
			}
		}

		public ICaptain Captain
		{
			get => this.captain;
			set
			{
				if (value == null)
				{
					throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
				}

				this.captain = value;
			}
		}

		public double ArmorThickness
		{
			get => this.armorThickness;
			set => this.armorThickness = value;
		}

		public double MainWeaponCaliber
		{
			get => this.mainWeaponCaliber;
			protected set => this.mainWeaponCaliber = value;
		}

		public double Speed
		{
			get => this.speed;
			protected set => this.speed = value;
		}

		public ICollection<string> Targets => this.targets;

		public void Attack(IVessel target)
		{
			if (target == null)
			{
				throw new NullReferenceException(ExceptionMessages.InvalidTarget);
			}

			target.ArmorThickness -= this.MainWeaponCaliber;

			if (target.ArmorThickness < 0)
			{
				target.ArmorThickness = 0;
			}

			this.targets.Add(target.Name);
		}

		public abstract void RepairVessel();

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"- {this.Name}").AppendLine($" *Type: {this.GetType().Name}");
			sb.AppendLine($" *Armor thickness: {this.ArmorThickness}").AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
			sb.AppendLine($" *Speed: {this.Speed} knots");
			sb.AppendLine($" *Targets: {(this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None")}");

			return sb.ToString().TrimEnd();
		}
	}
}
