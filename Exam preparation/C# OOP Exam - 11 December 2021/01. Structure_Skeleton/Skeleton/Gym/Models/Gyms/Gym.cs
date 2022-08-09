using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private readonly ICollection<IEquipment> equipment;
        private readonly ICollection<IAthlete> athletes;
        public Gym()
        {
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public Gym(string name, int capacity):this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight => this.Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if(athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete) => athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment) => this.equipment.Add(equipment);
        public void Exercise()
        {
            foreach(IAthlete athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType()}:")
                .AppendLine($"Athletes: {(athletes.Count > 0 ? (string.Join(" ,", athletes)) : "No athletes")}")
                .AppendLine($"Equipment total count: {this.Equipment}").
                Append($"Equipment total weight: {EquipmentWeight} grams");
            return sb.ToString().TrimEnd();
        }

        
    }
}
