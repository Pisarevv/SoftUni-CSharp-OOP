using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;
        private string name;
        private double budget;
        private double militaryPower;
        private Planet()
        {
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public Planet(string name, double budget):this()
        {
            this.Name = name;
            this.Budget = budget;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();
       

        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }
        public void TrainArmy()
        {
            foreach(IMilitaryUnit unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if(this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }
        public void Profit(double amount)
        {
            this.Budget += amount;
        }
        public string PlanetInfo()
        {
            List<string> weaponsInPlanet = new List<string>();
            List<string> unitsInPlanet = new List<string>();
            foreach(IWeapon weapon in weapons.Models)
            {
                weaponsInPlanet.Add(weapon.GetType().Name);
            }
            foreach(IMilitaryUnit unit in units.Models)
            {
                unitsInPlanet.Add(unit.GetType().Name);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"--Forces: {(this.units.Models.Count > 0 ? (string.Join(", ", unitsInPlanet)) : "No units")}")
                .AppendLine($"--Combat equipment: {(this.weapons.Models.Count > 0 ? (string.Join(", ", weaponsInPlanet)) : "No weapons")}")
                .Append($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().TrimEnd();
        }


        private double CalculateMilitaryPower()
        {
            double totalAmout = 0;
            foreach(IMilitaryUnit unit in units.Models)
            {
                totalAmout += unit.EnduranceLevel;
            }
            foreach (IWeapon weapon in weapons.Models)
            {
                totalAmout += weapon.DestructionLevel;
            }
            if(this.units.Models.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                double increasementPercent = 0.30;
                totalAmout += totalAmout * increasementPercent;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                double increasementPercent = 0.45;
                totalAmout += totalAmout * increasementPercent;
            }
            return Math.Round(totalAmout, 3);
        }
    }
}
