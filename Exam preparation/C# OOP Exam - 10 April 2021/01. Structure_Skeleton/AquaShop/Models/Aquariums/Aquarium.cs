namespace AquaShop.Models.Aquariums
{   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using Contracts;
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;


        public Aquarium()
        {
            this.Decorations = new HashSet<IDecoration>();
            this.Fish = new HashSet<IFish>();
        }
        public Aquarium(string name, int capacity):this()
        {
            this.Name = name;
            this.Capacity = capacity;
            
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
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
        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }
        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public void AddFish(IFish fish)
        {
            if(this.Fish.Count +1 > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.Fish.Add(fish);
        }
        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }     

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }
      
        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            List<string> fishesNames = new List<string>();
            foreach (IFish fish in Fish)
            {
                fishesNames.Add(fish.Name);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {(fishesNames.Count > 0 ? string.Join(", ", fishesNames) : "none")}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.Append($"Comfort {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
  

       

       /*public override string ToString()
        {
            
        }*/
    }
}
